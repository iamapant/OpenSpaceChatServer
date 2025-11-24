using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Api.Secrets;

public interface ISecretProvider {
    Task Initialize();
}

public static class SecretGenerationMethod{
    public const string UserInput = "input";
    public const string Id = "generated_id";
    public const string Random = "generated_random";
    // public const string Rsa2048 = "generated_rsa_2048";
    // public const string Rsa1024 = "generated_rsa_1024";
    
    public static string GenerateRandom(int length) {
        const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"; 
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        var str = new StringBuilder();
        var bytes = new byte[length];
        rng.GetBytes(bytes);

        foreach (var b in bytes) {
            var c = chars[b % chars.Length];
            str.Append(c);
        }

        return str.ToString();
    }
}

public class SecretProvider  : ISecretProvider {
    const string Path = "secrets.json";

    private async Task<List<SecretDescription>?> ReadSecrets() {
        using var file = File.OpenRead(Path);
        return await JsonSerializer.DeserializeAsync<List<SecretDescription>>(file);
    }
    public async Task Initialize() {
        try {
            var config = await ReadSecrets();
            foreach (var secret in config ?? []) {
                await CheckOrSetSecret(secret);
            }
        } catch (Exception e) {
            throw new Exception("Unable to initialize the secret provider", e);
        }
    }

    private async Task CheckOrSetSecret(SecretDescription secret) {
        var store = ISecretMiddleware.GetStore(secret.Store);
        if (await store.Check(secret.Name)) return;

        Console.WriteLine($"Missing required secret: {secret.Name} ({secret.Description})");
        var value = await GenerateSecret(secret);
        
        await store.Set(secret.Name, value);
    }

    private async Task<string> GenerateSecret(SecretDescription secret) {
        while (true) {
            try {
                string s;

                var inputMethods = secret.Source.Split('|').Select(e => e.ToLowerInvariant().Trim()).ToHashSet() ?? throw new Exception($"{secret.Name} does not contain an input source");

                string source;
                if (inputMethods.Count > 1) {
                    //ask the user to select the input method
                    source = SelectSource(inputMethods);
                }
                else source = secret.Source;
                
                s = source switch {
                    SecretGenerationMethod.UserInput => ConsoleExtensions.ReadSecret(),
                    SecretGenerationMethod.Id => Guid.CreateVersion7().ToString(),
                    SecretGenerationMethod.Random => SecretGenerationMethod.GenerateRandom(8),
                    _ => throw new Exception("invalid input source")
                };
                
                if (!string.IsNullOrWhiteSpace(s)) return s;
            } catch (Exception e) {
                Console.WriteLine($"Invalid secret.Reason: {e.Message}");
            }
        }
    }

    private string SelectSource(HashSet<string> inputMethods) {
        while (true) {
            try {
                int count = 1;
                Console.WriteLine($"Secret has multiple sources. Please pick one of the following: {string.Join(", ", inputMethods.Select(e => $"{count++}. {e}"))}");
                
                var source = Console.ReadLine();
                var selection = inputMethods.FirstOrDefault(e => string.Equals(e, source, StringComparison.OrdinalIgnoreCase));
                if (selection == null) {
                    if (int.TryParse(selection, out var res) && res > 0 && res <= inputMethods.Count) {
                        selection = inputMethods.ElementAt(res - 1);
                    }
                }
                if (selection == null) throw new Exception("Cannot find source");
                return selection;
            } catch (Exception e) {
                Console.WriteLine($"Invalid source.Reason: {e.Message}");
            }
        }
    }
}

public struct SecretDescription {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Source { get; set; }
    public string Store { get; set; }
}

public interface ISecretMiddleware {
    Task<bool> Check(string name);
    Task<string?> Get(string name);
    Task Set(string name, string value);

    public static ISecretMiddleware GetStore(string store) {
        return store switch {
            "user-secret" or "user-secrets" => new UserSecretsMiddleware(),
            _ => throw new ArgumentOutOfRangeException(nameof(store), store, null)
        };
    } 
}

public class UserSecretsMiddleware : ISecretMiddleware {
    public async Task<bool> Check(string name) => throw new NotImplementedException();

    public async Task<string?> Get(string name) => throw new NotImplementedException();

    public async Task Set(string name, string value) => throw new NotImplementedException();
}

