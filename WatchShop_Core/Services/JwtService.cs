using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchShop_Core.Domain.Entities.Identities;
using WatchShop_Core.ServiceContracts;

namespace WatchShop_Core.Services
{
    public class JwtService : IJwtService
    {
        private string _secretKey;
        private readonly UserManager<ApplicationUser> _userManager;

        public JwtService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _userManager = userManager;
        }

        public async Task<string> CreateJwtTokenAsync(ApplicationUser applicationUser)
        {
            var roles = await _userManager.GetRolesAsync(applicationUser);

            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_secretKey);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", applicationUser.Id.ToString()),
                    new Claim("username", applicationUser.UserName),                  
                    new Claim("email", applicationUser.Email),                  
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
