using System;
using System.ServiceModel;

namespace FrameworkService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUpdateService
    {
         [OperationContract]
        string SaveChanges(string sqlStatements);
        [OperationContract]
         string GetWithSql(string className, string sqlStatements);
        [OperationContract]
        string GetWithSp(String Sql, int TimeoutSecs);
    }
}
