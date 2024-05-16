using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PizzaHutClone.Models;

namespace PizzaHutClone.Services
{
    public class TokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            string? _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }
        public string GenerateToken(Customer customer)
        {
            var claims = new List<Claim>(){
                new Claim("eid", customer.CustomerId.ToString())
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
            string token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }
    }
}
