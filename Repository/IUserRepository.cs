using System;
using System.Threading.Tasks;
using Boytrix.Logic.DataTransfer.Model;

namespace Boytrix.Logic.DataTransfer.Repository
{
    public interface IUserRepository
    {
         //User GetAll(string logon);
        void LogUserSession(User user);
        Task<User> GetUserFromDB(int UserID);
        Task<User> GetUserFromDB(String UserLogin);
    }
}
