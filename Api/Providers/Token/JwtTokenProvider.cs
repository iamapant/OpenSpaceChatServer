using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Claims;
using Api.DAL;
using Api.Database.Models;
using Microsoft.IdentityModel.Tokens;

namespace Api.Providers.Token;

public class JwtTokenProvider {

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
         || !jwtToken.Header.Alg.Equals(_settings.Algorithm, StringComparison.InvariantCultureIgnoreCase)) {
            Debug.WriteLine("Invalid token");
            t = null;
            return null;
        }

        t = jwtToken;
        return principal;
    }

    private JwtSettings _settings;

    public JwtTokenProvider(IGlobalSettings globalSettings) { _settings = globalSettings.Jwt; }

    public JwtSecurityToken Create(JwtClaims user) {
        var claims = new List<Claim>();
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.Name));
        claims.Add(new Claim(ClaimTypes.Role, user.Role));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToString("o")));

        //Remove duplicated claims
        var additional = user.Additional.Where(e => 
            e.Type != JwtRegisteredClaimNames.Sub
         && e.Type != JwtRegisteredClaimNames.Name 
         && e.Type != ClaimTypes.Role 
         && e.Type != JwtRegisteredClaimNames.Jti 
         && e.Type != JwtRegisteredClaimNames.Iat);
        
        
        claims.AddRange(additional.Select(c => new Claim(c.Type, c.Value)));
        if (!claims.Any(c => c.Type is JwtRegisteredClaimNames.Exp or ClaimTypes.Expiration)) 
            claims.Add(new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddMinutes(_settings.TokenExpireInMinute).ToString("o")));

        return new JwtSecurityToken(
            issuer: _settings.Issuer
          , audience: _settings.Audience
          , claims: claims
          , notBefore: DateTime.UtcNow
          , signingCredentials: _settings.SigningCredentials);
    }
    
    public record JwtClaims(string Id, string Name, string Role, params AdditionalClaims[] Additional);
    public record AdditionalClaims(string Type, string Value);
}