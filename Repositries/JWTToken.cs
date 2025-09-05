using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace WebAPICodeDemo.Repositries
{
    public class JWTToken : ITokenRepositry
    {
        private readonly IConfiguration _configuration;
        public JWTToken(IConfiguration configuration)
        { 
            this._configuration = configuration;
        }
        public string CreateToken(IdentityUser user, List<string> ROles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in ROles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var cridential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires:DateTime.Now.AddMinutes(5), signingCredentials: cridential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
