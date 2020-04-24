using System;
using System.Threading.Tasks;
using CrmApiLogic.Interfaces;
using CrmApiLogic.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace CrmApiLogic.Repositories
{
    public class UserRepository : GenericRepository<CrmUser>, IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userMng;

        public UserRepository(DataContext dataContext, UserManager<ApplicationUser> userManager) : base(dataContext)
        {
            _userMng = userManager;
        }

        public async Task<string> GetAuthToken(string username, string password, JwtConfiguration configuration)
        {
            var user = await _userMng.FindByNameAsync(username).ConfigureAwait(false);

            if (user == null)
            {
                return null;
            }

            var isOk = await _userMng.CheckPasswordAsync(user, password).ConfigureAwait(false);
            if (!isOk)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //TODO more claims for custom security policies
                    new Claim(ClaimTypes.Name, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(configuration.ExpiryDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
