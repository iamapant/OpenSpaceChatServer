using System.Security.Cryptography;

namespace Api;

public static class EnumerableExtension {
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> str) {
        var shuffled = str.ToList();
        return Shuffle(shuffled);
    }
    public static List<T> Shuffle<T>(this List<T> list) {
        for (int i = 0; i < list.Count; i++) {
            var rand = Rand(i);

            (list[i], list[rand]) = (list[rand], list[i]);
        }
        return list;

        int Rand(int i) {
            var x = i;
            while (x == i) x = RandomNumberGenerator.GetInt32(list.Count - 1);
            return x;
        }
    }
}