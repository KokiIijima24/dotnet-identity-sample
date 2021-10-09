using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotnet_identity_sample.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_identity_sample.Services
{
    public class TokenService
    {
        public string CreateToken(AppUser user){
          var claims = new List<Claim>{
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
          };

          // ToDo: set a secret string
          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
          var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

          var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires = System.DateTime.Now.AddDays(7),
            SigningCredentials = creds
          };

          var tokenHandler = new JwtSecurityTokenHandler();

          var token = tokenHandler.CreateToken(tokenDescriptor);

          return tokenHandler.WriteToken(token);
        }
    }
}