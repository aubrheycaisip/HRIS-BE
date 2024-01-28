using HRIS_BE.Helpers.Interfaces;
using HRIS_BE.Helpers.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRIS_BE.Helpers.Services
{
    [ServiceDependency(serviceType: typeof(IJwtService))]
    public class JwtService : IJwtService
    {
        public string GenerateJwtToken(UserLogin username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2fd8e5c594b8c13a95e25acce779e3b9e1013d7c8be555c3727a019eb121b188"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "HRIS_ISSUER",
                audience: "HRIS_AUDIENCE",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
