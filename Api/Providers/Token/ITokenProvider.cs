using System.Security.Cryptography;
using System.Text;
using Api.Database.Models;

namespace Api.Providers.Token;

public interface ITokenProvider<TTokenType> where TTokenType : notnull {
    ValidationResult<TTokenType> Validate(string? token);
    TTokenType Create(User user, object? keys = null);
    
    public static string GenerateRandomCharacters(int length, string allowedChars) {
        if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
        if (string.IsNullOrEmpty(allowedChars))  throw new ArgumentNullException(nameof(allowedChars));
        
        var token = new StringBuilder(length);
        char[] chars = allowedChars.ToCharArray();
        var charsLength = chars.Length;

        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        var randomBytes = new byte[length];
        rng.GetBytes(randomBytes);
        
        for (int i = 0; i < length; i++) 
            token.Append(chars[randomBytes[i] % charsLength]);
        
        return token.ToString();
    }  
}