using System.ServiceModel;

namespace Boytrix.Data.Services.WCF.BoytrixModules.OrderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
         string GetShippingMethodListFromService();
      
    }
    
}
