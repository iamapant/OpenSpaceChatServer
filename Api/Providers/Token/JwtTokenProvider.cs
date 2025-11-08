using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;
using Api.DAL;
using Api.Database.Models;
using Microsoft.IdentityModel.Tokens;

namespace Api.Providers.Token;

public class JwtTokenProvider
    : ITokenProvider<JwtSecurityToken> {
    public ValidationResult<JwtSecurityToken> Validate(string? token) {
        var res = new ValidationResult<JwtSecurityToken>();
        if (string.IsNullOrWhiteSpace(token))
            return new(new ArgumentNullException(token), this);

        var claims = ValidateToken(token, out var t);
        if (t is not JwtSecurityToken jwtToken)
            res.AddError(new Exception("Invalid token"));
        else res.Value = jwtToken;
        return res;
    }

    public ClaimsPrincipal? ValidateToken(string? token, out SecurityToken? t) {
        if (_settings.Handler == null || _settings.TokenValidationParameters == null) {
            Debug.WriteLine(
                "Jwt token handler or token validation parameters not configured");
            t = null;
            return null;
        }

        var principal = _settings.Handler.ValidateToken(token
          , _settings.TokenValidationParameters
          , out var validatedToken);

        if (validatedToken is not JwtSecurityToken jwtToken
         || !jwtToken.Header.Alg.Equals(_settings.Algorithm
              , StringComparison.InvariantCultureIgnoreCase)) {
            Debug.WriteLine("Invalid token");
            t = null;
            return null;
        }

        t = jwtToken;
        return principal;
    }

    private JwtSettings _settings;

    public JwtTokenProvider(GlobalSettings globalSettings) { _settings = globalSettings.Jwt; }

    public JwtSecurityToken Create(User user, object? keys = null) {
        var r = keys.Reflect();
        var claims = new List<Claim>();
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        AdditionalClaims();

        return new JwtSecurityToken(
            issuer: _settings.Issuer
          , audience: _settings.Audience
          , claims: claims
          , notBefore: DateTime.UtcNow
          , signingCredentials: _settings.SigningCredentials);

        void AdditionalClaims() {
            if (!r.HasValue) return;
            if (r.TryGetProperty("expire", out object? t, false)) {
                switch (t) {
                    case TimeSpan ts:
                        claims.Add(
                            new Claim(JwtRegisteredClaimNames.Exp
                              , DateTimeOffset.UtcNow.Add(ts).ToUnixTimeSeconds().ToString()));
                        break;
                    case DateTime dt:
                        claims.Add(new Claim(JwtRegisteredClaimNames.Exp, dt.ToString("o")));
                        break;
                }
            }
            if (r.TryGetProperty("email", out object? e, false)) {
                switch (e) {
                    case string email:
                        claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
                        break;
                    case /*bool and*/ true:
                        claims.Add(new Claim(JwtRegisteredClaimNames.Email
                          , user.UserInfo.Email));
                        break;
                }
            }

            if (r.TryGetProperty("phone", out object? p, false)) {
                switch (p) {
                    case string phone:
                        claims.Add(new Claim(JwtRegisteredClaimNames.PhoneNumber, phone));
                        break;
                    case true when user.UserInfo.Phone != null:
                        claims.Add(new Claim(JwtRegisteredClaimNames.PhoneNumber
                          , user.UserInfo.Phone));
                        break;
                }
            }

            //Other claims
            var otherClaims = r.Properties()
                               .Where(prop => 
                                   !prop.Name.Contains("expire"
                                     , StringComparison.OrdinalIgnoreCase)
                                && !prop.Name.Contains("email"
                                     , StringComparison.OrdinalIgnoreCase)
                                && !prop.Name.Contains("phone"
                                     , StringComparison.OrdinalIgnoreCase))
                               .Select(prop => new KeyValuePair<string, string>(prop.Name
                                 , prop.GetValue(keys)?.ToString() ?? ""))
                               .Where(prop => prop.Value.Length > 0)
                               .ToList();

            claims.AddRange(otherClaims.Select(claim => new Claim(claim.Key, claim.Value)));
        }
    }
}