using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.Providers.Token;

public class JwtSettings {
    public string Issuer { get; set; }
    public string Audience { get; set; }
    
    public string Secret { get; set; }
    public string Algorithm { get; set; } = SecurityAlgorithms.HmacSha256;
    public float TokenExpireInMinute { get; set; }
    
    public SigningCredentials SigningCredentials 
    => new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)), Algorithm);

    //Bind manually
    public JwtSecurityTokenHandler? Handler { get; set; } = new ();
    public TokenValidationParameters? TokenValidationParameters { get; set; } = new();
}

