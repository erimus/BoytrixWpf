using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.DataTransfer.Proxies.User
{
   public interface IUserServiceClientData
    {
        Task<string> GetUserFromDBFromLoginFromService(string logon);
        Task<string> GetUserFromDBFromUserIdFromService(int userid);
        Task<string> GetUsersFromDB();

    }
}
