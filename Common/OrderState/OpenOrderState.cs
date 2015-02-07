namespace Boytrix.Logic.Business.Common.OrderState
{
    public class OpenOrderState:IOrderState
    {
        public bool CanOpenOrder(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public void OpenOrder(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public bool CanShipment(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public void Shipment(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public bool CanStatusCheck(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public void StatusCheck(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public bool CanShippingMethod(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public void ShippingMethod(OrderContext order)
        {
            throw new System.NotImplementedException();
        }

        public OrderStatus Status
        {
            get { return OrderStatus.OpenOrder; } 
        }
    }
}
