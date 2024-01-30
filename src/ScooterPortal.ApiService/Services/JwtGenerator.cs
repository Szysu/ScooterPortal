using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ScooterPortal.ApiService.Services;

public class JwtGenerator
{
    private readonly byte[] _key;

    public JwtGenerator(IConfiguration config)
    {
        if (config["JwtKey"] is null or "")
        {
            throw new InvalidDataException("JwtKey is not set");
        }

        _key = Encoding.UTF8.GetBytes(config["JwtKey"]!);
    }

    public string GenerateToken(Administrator admin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new Claim(ClaimTypes.Name, admin.FullName)
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}