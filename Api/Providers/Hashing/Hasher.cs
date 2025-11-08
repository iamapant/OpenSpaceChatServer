using Api.Hashing;

namespace Api.Providers.Hashing;

public abstract class Hasher {
    public static Hasher Current { get; set; } = new Argon2Hasher();
    public abstract string Hash(string password);
    public abstract bool Verify(string password, string hashedPassword);
}