using System.Security.Cryptography;
using System.Text;
using Api.Database.Models;

namespace Api.Providers.PasswordGenerator;

public static class PasswordGenerator {
    public static string GeneratePassword(AdminSettings settings) {
        var req = 1;
        var length = settings.PasswordDefaultLength;
        if (settings.PasswordContainsNumber) req++;
        if (settings.PasswordContainsSpecial) req++;
        if (settings.PasswordContainsUpper) req++;
        if (settings.PasswordContainsLower) req++;
        if (length < settings.PasswordMinLength)
            throw new Exception(
                "Password length must be greater than or equal to minimum length.");
        if (length < req)
            throw new Exception(
                "Password length must be greater than or equal to the types of characters required.");

        var str = new List<char>(length);

        //Get valid charset
        var charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        foreach (var c in settings.PasswordAllowedSpecials) charset += c;
        foreach (var c in settings.PasswordExcludedCharacters) {
            var indexOf = charset.IndexOf(c);
            if (indexOf < 0) continue;
            str.RemoveAt(indexOf);
        }

        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        var bytes = new byte[length];
        rng.GetBytes(bytes);

        int i = 0;
        if (settings.PasswordContainsNumber)
            str.Add(NumberCharset()[bytes[i++] % NumberCharset().Length]);
        if (settings.PasswordContainsSpecial)
            str.Add(SpecialCharset()[bytes[i++] % SpecialCharset().Length]);
        if (settings.PasswordContainsLower)
            str.Add(LowerCaseCharset()[bytes[i++] % LowerCaseCharset().Length]);
        if (settings.PasswordContainsUpper)
            str.Add(UpperCaseCharset()[bytes[i++] % UpperCaseCharset().Length]);

        while (i < length) { str.Add(charset[bytes[i++] % charset.Length]); }

        return new string(str.Shuffle().ToArray());

#region Segregate charset
        string NumberCharset() {
            return new string(charset.Where(char.IsDigit).ToArray());
        }

        string SpecialCharset() {
            return new string(charset.Where(c => !char.IsLetterOrDigit(c)).ToArray());
        }

        string LowerCaseCharset() {
            return new string(charset.Where(char.IsLower).ToArray());
        }

        string UpperCaseCharset() {
            return new string(charset.Where(char.IsUpper).ToArray());
        }
#endregion
    }
}