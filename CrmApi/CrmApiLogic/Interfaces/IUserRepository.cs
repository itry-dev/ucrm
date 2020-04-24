using System;
using System.Threading.Tasks;
using CrmApiLogic.Models;

namespace CrmApiLogic.Interfaces
{
    public interface IUserRepository : IRepository<CrmUser>
    {

        /// <summary>
        /// Gets the authentication token for the user identified by its credentials.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Task<string> GetAuthToken(string username, string password, JwtConfiguration configuration);
    }
}
