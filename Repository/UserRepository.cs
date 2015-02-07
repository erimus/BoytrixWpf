
//using Boytrix.Logic.Business.Common;
//using Boytrix.Logic.DataTransfer.Proxies.User;
//using Boytrix.Logic.Model.Classes.UserData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//namespace Boytrix.Logic.DataTransfer.Repository
//{
//    public class UserRepository : IUserRepository
//    {
//       public UserRepository(IUserServiceClientData serviceClient)
//       {

//       }

//       private async Task<User> ServiceCallAsync(string logon)
//        {
//            var proxy = new UserServiceClientData();

//            string theXml = await proxy.GetUserFromDBFromLoginFromService(logon);


//            try
//            {
//                StringBuilder sb = new StringBuilder();
//                XDocument source = XDocument.Parse(theXml);

//                //Get security permisions
//                XName itemName = XName.Get("SecurityPermission", source.Root.Name.NamespaceName);
               
//                foreach (XElement item in source.Descendants(itemName))
//                {
//                   // Console.WriteLine(item.ToString());
//                    sb.Append(item.ToString());

//                }


//              //Get user

//                IList<SecurityPermission> securityPermissions = BoytrixSerializer.DeserializeParams<SecurityPermission>(sb.ToString());


//                itemName = XName.Get("User", source.Root.Name.NamespaceName);
              
               
//                foreach (XElement item in source.Descendants(itemName))
//                {
//                   //build xml doc
//                    sb.Append(item.ToString());

//                }

//                IList<User> user = BoytrixSerializer.DeserializeParams<User>(sb.ToString());

//                user[0].UserPermissions = securityPermissions;

//                return user[0];
//            }
//            catch (Exception ex)
//            {
//                throw (ex);
//            }
//        }


//        public void LogUserSession(User user)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<User> GetUserFromDB(int UserID)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<User> GetUserFromDB(string UserLogin)
//        {
//            User j = await ServiceCallAsync(UserLogin);
//            return j;
//        }


  
//    }
//}
