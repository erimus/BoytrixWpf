
using System.Collections.Generic;
using System.Threading.Tasks;
using Boytrix.Logic.DataTransfer.Model;

namespace Boytrix.UI.WPF.BoytrixModules.Order.DataServices
{
    public interface  IOrderDataService
    {
        //ObservableCollection<ShippingMethod> GetShippingMethods();
        Task<IList<ShippingMethod>> GetShippingMethods();
    }
}
