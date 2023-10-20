using Infrastructure.Auth.Models;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Auth;

public class JwtCreator
{
  private readonly IConfiguration _config;

  public JwtCreator(IConfiguration config)
  {
    _config = config;
  }

  public string GenerateToken(AppUser user)
  {
    var jwtSettings = _config.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

    if (jwtSettings is null)
    {
      throw new ArgumentNullException("Jwt setting cannot be null");
    }

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    List<Claim> claims = new()
    {
      new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
      new Claim(ClaimTypes.Email,user.Email),
    };

    var token = new JwtSecurityToken(
     jwtSettings.Issuer,
     jwtSettings.Audience,
     claims,
     expires: DateTime.Now.AddMinutes(60),
     signingCredentials: credentials);


    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}
