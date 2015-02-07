
using Boytrix.Logic.DataTransfer.Repository;

namespace Boytrix.UI.WPF.BoytrixModules.Order.DataServices
{
    public class OrderDataService 
    {
        OrderRepository repository;
        public OrderDataService(OrderRepository repository)
        {
            this.repository = repository;
           // GetShippingMethods();
        }




        public void GetShippingMethods()
        {
            repository.GetModelData((o, e) => { });
        }
    }
}
