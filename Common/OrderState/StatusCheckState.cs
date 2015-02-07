using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.Business.Common.OrderState
{
    public class StatusCheckState:IOrderState
    {
        public bool CanOpenOrder(OrderContext order)
        {
            return true;
        }

        public void OpenOrder(OrderContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanShipment(OrderContext order)
        {
            throw new NotImplementedException();
        }

        public void Shipment(OrderContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanStatusCheck(OrderContext order)
        {
            throw new NotImplementedException();
        }

        public void StatusCheck(OrderContext order)
        {
            throw new NotImplementedException();
        }

        public bool CanShippingMethod(OrderContext order)
        {
            throw new NotImplementedException();
        }

        public void ShippingMethod(OrderContext order)
        {
            throw new NotImplementedException();
        }

        public OrderStatus Status
        {
            get { return OrderStatus.StatusCheck; }
        }
    }
}
