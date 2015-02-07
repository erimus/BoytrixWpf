

using System.Collections.Generic;
using System.Threading.Tasks;
using Boytrix.Logic.DataTransfer.Model;

namespace Boytrix.Logic.DataTransfer.Repository
{
    public interface IOrderRepository 
    {
        Task<IList<ShippingMethod>> GetShippingMethods();
    }
}
