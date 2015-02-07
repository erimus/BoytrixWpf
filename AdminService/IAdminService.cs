using System.ServiceModel;

namespace Boytrix.Data.Services.WCF.Admin.AdminService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminService" in both code and config file together.
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
         string GetShippingMethodListFromService();

    }
}
