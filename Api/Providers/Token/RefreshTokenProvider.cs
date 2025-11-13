using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Api.DAL;
using Api.Database.Models;

namespace Api.Providers.Token;

public class RefreshTokenProvider(IGlobalSettings globalSettings) : ITokenProvider<string> {
    public ValidationResult<string> Validate(string? token) {
        if (string.IsNullOrEmpty(token)) return new (new ArgumentNullException(token));
        if (!TryParse(token, out var parts))  return new (new FormatException("Refresh token format"), this);
        if (parts.Created.AddHours(globalSettings.Admin.RefreshTokenTimeoutInHour) <= DateTime.UtcNow) return new (new TimeoutException("Refresh token expired."), this);

        return new (token);
    }

    private bool TryParse(string token, [MaybeNullWhen(false)] out TokenParts parts) {
        try {
            var split = token.Split(globalSettings.Admin.RefreshTokenSeparator);
            if (split.Length != 2) throw new FormatException("Invalid token format");
            if (globalSettings.Admin.RefreshTokenLength != split[0].Length) throw new FormatException("Invalid token format");
            if (!Regex.IsMatch(split[0], $"^[{globalSettings.Admin.RefreshTokenCharacters}]+$")) throw new FormatException("Invalid token format");
            if (!long.TryParse(split[1], out var timestamp)) throw new FormatException("Invalid token format");
            
            parts = new (split[0], new DateTime(timestamp));
            return true;
        } catch {
            parts = default;
            return false;
        }
    }

    public string Create(User user, object? keys = null) {
        var key = ITokenProvider<string>.GenerateRandomCharacters(globalSettings.Admin.RefreshTokenLength, globalSettings.Admin.RefreshTokenCharacters);
        var token = new TokenParts(key, DateTime.UtcNow);
        return token.ToToken(separator: globalSettings.Admin.RefreshTokenSeparator);
    }

    private record struct TokenParts(string Token, DateTime Created) {
        public string ToToken(char separator) =>
            $"{Length19Stamp(Created)}{separator}{Token}";

        private string Length19Stamp(DateTime timestamp) {
            var str = timestamp.Ticks.ToString();
            while (str.Length < 19) {
                str = "0" + str;
            }
            return str;
        }
    }
}