using Isopoh.Cryptography.Argon2;

namespace Api.Hashing;

public class Argon2Hasher : Hasher {
    public override string Hash(string password) => Argon2.Hash(password);

    public override bool Verify(string password, string hashedPassword) => Argon2.Verify(password, hashedPassword);
}