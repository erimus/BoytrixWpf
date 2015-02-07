


//using Boytrix.Logic.DataTransfer.Repository;
//using Boytrix.Logic.Model.Classes.UserData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Boytrix.UI.WPF.BoytrixModules.Login.DataServices
//{
//    public class UserDataService : IUserDataService
//    {
//        private UserRepository repository;
//        public UserDataService(IUserRepository repository)
//        {
//            this.repository =(UserRepository) repository;
           
//        }

//        private   async void GetUser()
//        {
//           var j=await  GetUserFromDB("Wasi");
//           User = j;
//        }
//        public Task<IList<User>> GetUserFromDB(int UserID)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<User> GetUserFromDB(string Login)
//        {
//            var myList = await repository.GetUserFromDB(Login);
//            return myList;
//        }

//        Task<User> IUserDataService.GetUserFromDB(int UserID)
//        {
//            throw new NotImplementedException();
//        }


//        public User User { get; set; }
        
//    }
//}

