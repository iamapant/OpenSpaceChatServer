using System.Diagnostics.CodeAnalysis;
using System.Text;
using TextCopy;

namespace Api;

public static class ConsoleExtensions {
    public static string ReadSecret() {
        var buffer = new ReadSecretBuffer();
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter) {
            if (!SpecialKeys.DoSpecial(key, buffer)) 
                buffer.OnKeyPressed(key);
        }

        Console.WriteLine();
        return buffer.ToString();
    }

    private static class SpecialKeys {
        public static readonly HashSet<char> BreakCharacters = new() {
            '.',',',';','|','-',
        };
        public static bool IsSpecial(ConsoleKeyInfo key
          , [MaybeNullWhen(false)] out SpecialKey special) {
            special = Specials.FirstOrDefault(s => s.IsSpecialKey(key));
            return special != null;
        }

        public static bool DoSpecial(ConsoleKeyInfo key, ReadSecretBuffer buffer) {
            if (!IsSpecial(key, out var special)) return false;
            special.Action(buffer);
            return true;
        }

        public record SpecialKey(
            Func<ConsoleKeyInfo, bool> IsSpecialKey
          , Action<ReadSecretBuffer> Action);

        public static readonly List<SpecialKey> Specials = new List<SpecialKey> {
            //Backspace
            new SpecialKey(
                IsSpecialKey: key => key.Key == ConsoleKey.Backspace
              , Action: buffer => {
                    if (buffer.DeleteSelectionIfAny()) return;
                    if (buffer.Cursor <= 0) return;
                    buffer.Buffer.RemoveAt(buffer.Cursor - 1);
                    buffer.Cursor--;
                }
            ),
            //Delete
            new SpecialKey(
                IsSpecialKey: key => key.Key == ConsoleKey.Delete
              , Action: buffer => {
                    if (buffer.DeleteSelectionIfAny()) return;
                    if (buffer.Cursor >= buffer.Buffer.Count) return;
                    buffer.Buffer.RemoveAt(buffer.Cursor - 1);
                    buffer.Cursor--;
                }
            ),
            //Home
            new SpecialKey(
                IsSpecialKey: key => key.Key == ConsoleKey.Home
              , Action: buffer => {
                    buffer.ClearSelection();
                    buffer.Cursor = 0;
                }
            ),
            //End
            new SpecialKey(
                IsSpecialKey: key => key.Key == ConsoleKey.End
              , Action: buffer => {
                    buffer.ClearSelection();
                    buffer.Cursor = buffer.Buffer.Count;
                }
            ),
            //Left arrow
            new SpecialKey(
                IsSpecialKey: key => key is
                    { Key: ConsoleKey.LeftArrow, Modifiers: ConsoleModifiers.None }
              , Action: buffer => {
                    buffer.ClearSelection();
                    buffer.Cursor--;
                }
            ),
            //Right arrow
            new SpecialKey(
                IsSpecialKey: key => key is
                    { Key: ConsoleKey.RightArrow, Modifiers: ConsoleModifiers.None }
              , Action: buffer => {
                    buffer.ClearSelection();
                    buffer.Cursor++;
                }
            ),
            //Shift left
            new SpecialKey(
                IsSpecialKey: key => key is { Key: ConsoleKey.LeftArrow, Modifiers: ConsoleModifiers.Shift }
              , Action: buffer => {
                    if (buffer.Cursor > 1)buffer.SelectedIndex.Add(buffer.Cursor - 1);
                    buffer.Cursor--; 
                }
            ),
            //Shift right
            new SpecialKey(
                IsSpecialKey: key => key is { Key: ConsoleKey.RightArrow, Modifiers: ConsoleModifiers.Shift }
              , Action: buffer => {
                    if (buffer.Cursor == buffer.Buffer.Count)buffer.SelectedIndex.Add(buffer.Cursor);
                    buffer.SelectedIndex.Add(buffer.Cursor);
                    buffer.Cursor++; 
                }
            ),
            //Ctrl left
            new SpecialKey(
                IsSpecialKey: key => key is { Key: ConsoleKey.LeftArrow, Modifiers: ConsoleModifiers.Control }
              , Action: buffer => {
                    buffer.ClearSelection();
                    if (buffer.Cursor == 0) return;
                    while (buffer.Cursor > 0 && !BreakCharacters.Contains(buffer.Buffer[buffer.Cursor])) {
                        buffer.Cursor--;
                        if (buffer.Cursor == 0) break;
                    }
                }
            ),
            //Ctrl right
            new SpecialKey(
                IsSpecialKey: key => key is { Key: ConsoleKey.LeftArrow, Modifiers: ConsoleModifiers.Control }
              , Action: buffer => {
                    buffer.ClearSelection();
                    if (buffer.Cursor == buffer.Buffer.Count) return;
                    while (buffer.Cursor < buffer.Buffer.Count && !BreakCharacters.Contains(buffer.Buffer[buffer.Cursor])) {
                        buffer.Cursor++;
                        if (buffer.Cursor == buffer.Buffer.Count) break;
                    }
                }
            ),
            //Shift ctrl left
            new SpecialKey(
                IsSpecialKey: key => key is { Key: ConsoleKey.LeftArrow, Modifiers: ConsoleModifiers.Control }
              , Action: buffer => {
                    buffer.ClearSelection();
                    if (buffer.Cursor == 0) return;
                    while (buffer.Cursor > 0 && !BreakCharacters.Contains(buffer.Buffer[buffer.Cursor])) {
                        buffer.SelectedIndex.Add(buffer.Cursor);
                        buffer.Cursor--;
                        if (buffer.Cursor == 0) break;
                    }
                }
            ),
            //Shift ctrl right
            new SpecialKey(
                IsSpecialKey: key => key is { Key: ConsoleKey.LeftArrow, Modifiers: ConsoleModifiers.Control }
              , Action: buffer => {
                    buffer.ClearSelection();
                    if (buffer.Cursor == buffer.Buffer.Count) return;
                    while (buffer.Cursor < buffer.Buffer.Count && !BreakCharacters.Contains(buffer.Buffer[buffer.Cursor])) {
                        buffer.Cursor++;
                        buffer.SelectedIndex.Add(buffer.Cursor);
                        if (buffer.Cursor == buffer.Buffer.Count) break;
                    }
                }
            ),
            //All
            new SpecialKey(
                IsSpecialKey: key => key.Key == ConsoleKey.Delete
              , Action: buffer => {
                    if (buffer.Cursor >= buffer.Buffer.Count) return;
                    buffer.Buffer.RemoveAt(buffer.Cursor - 1);
                    buffer.Cursor--;
                }
            ),
            //Paste
            new SpecialKey(
                IsSpecialKey: key => key.Key == ConsoleKey.V
                 && key.Modifiers.HasFlag(ConsoleModifiers.Control)
              , Action: buffer => {
                    var paste = new Clipboard().GetText();
                    if (string.IsNullOrEmpty(paste)) return;

                    foreach (var c in paste.Where(p => !char.IsControl(p))) {
                        buffer.Insert(c);
                    }
                }
            ),
        };
    }
}

public class ReadSecretBuffer {
    public List<char> Buffer = new List<char>();
    public HashSet<int> SelectedIndex = new HashSet<int>();

    public int Cursor {
        get;
        set {
            if (value < 0 || value > Buffer.Count) return;
            field = value;
        }
    }

    public void OnKeyPressed(ConsoleKeyInfo key) {
        if (char.IsControl(key.KeyChar)) return;
        if (SelectedIndex.Count != 0) {
            foreach (var i in SelectedIndex.Where(i => Buffer.Count <= i)) {
                Buffer.RemoveAt(i);
            }

            SelectedIndex.Clear();
        }

        Insert(key.KeyChar);
    }

    public void Insert(char keyChar) {
        Buffer.Insert(Cursor, keyChar);
        Cursor++;
    }
    
    public void ClearSelection() {
        SelectedIndex.Clear();
    }

    public bool DeleteSelectionIfAny() {
        if (SelectedIndex.Count <= 0) return false;
        DeleteSelection();
        return true;

    }

    public void DeleteSelection() {
        foreach (var i in SelectedIndex) {
            if (i < Cursor) Cursor--;
            Buffer.RemoveAt(i);
        }
    }
    
    public override string ToString() => string.Join("", Buffer);
}