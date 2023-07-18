using Microsoft.IdentityModel.Tokens;
using PaymentAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaymentAPI.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(3),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserEmail",user.Email),
                    new Claim("UserID", user.Id.ToString()),
                    new Claim("Expires", Expires.ToString())
                }),
                
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public DateTime Expires { get; set; } = DateTime.UtcNow.AddHours(3);
    }
}
