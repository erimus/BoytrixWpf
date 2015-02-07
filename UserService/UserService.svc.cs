using System;
using Boytrix.Data.DAL.DataAccess;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {

        public string GetUserFromDBFromId(int UserID)
        {
            throw new NotImplementedException();
        }

        public string GetUserFromDBFromLogin(string Login)
        {
            var dal = new UserDal();
            string theXml = dal.GetUserFromDB(Login);
            return theXml;
        }

        public string GetUsersFromDB()
        {
            var dal = new UserDal();
            string theXml = dal.GetUsersFromDB();
            return theXml;
        }
    }
}
