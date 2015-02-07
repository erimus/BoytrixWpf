using System;
using System.ServiceModel;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        string GetUserFromDBFromId(int UserID);
         [OperationContract]
        string GetUserFromDBFromLogin(String Login);
        // TODO: Add your service operations here
         [OperationContract]
        string GetUsersFromDB();
    }   
}
