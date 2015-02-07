//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Boytrix.Logic.DataTransfer.Proxies.User
//{
//    public class UserServiceClientData : IUserServiceClientData
//    {

//        public async Task<string> GetUserFromDBFromLoginFromService(string logon)
//        {
//            string task = await GetUserFromDBFromLoginFromServiceAsync(logon);
//            return task;
//        }

//        public  Task<string> GetUserFromDBFromUserIdFromService(int userid)
//        {
//            throw new NotImplementedException();
//        }

//        private async Task<string> GetUserFromDBFromLoginFromServiceAsync(string login)
//        {
//            var proxy = new UserServiceReference.UserServiceClient();

//            Debug.WriteLine("UserServiceClient instantiated");


//            System.Diagnostics.Debug.WriteLine("Get user Method Async called");
//            var Result = await proxy.GetUserFromDBFromLoginAsync(login);
//            return Result;
//        }

//        Task<string> IUserServiceClientData.GetUsersFromDB()
//        {
//            var proxy = new UserServiceReference.UserServiceClient();

//            Debug.WriteLine("UserServiceClient instantiated");


//            System.Diagnostics.Debug.WriteLine("Get user Method Async called");
//            var Result = await proxy.GetUserFromDB(login);
//            return Result;
//        }
//    }
//}
