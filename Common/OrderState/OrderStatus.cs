using System;

namespace Boytrix.Logic.Business.Common.OrderState
{
    public enum OrderStatus
    {
        OpenOrder,
        Shipment,
        StatusCheck,
        ShippingMethod
    }

    public interface IOrderState
    {

        bool CanOpenOrder(OrderContext order);
        void OpenOrder(OrderContext order);
        bool CanShipment(OrderContext order);
        void Shipment(OrderContext order);
        bool CanStatusCheck(OrderContext order);
        void StatusCheck(OrderContext order);
        bool CanShippingMethod(OrderContext order);
        void ShippingMethod(OrderContext order);
        OrderStatus Status { get; }
    }

    public class OrderContext
    {
        private IOrderState _orderState;

        public OrderContext(IOrderState orderState)
        {
            _orderState = orderState;
        }

        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderStatus Status
        {
            get { return _orderState.Status; }
        }

        public bool CanOpenOrder()
        {
            return _orderState.CanOpenOrder(this);
        }

        public void OpenOrder()
        {
            if (CanOpenOrder())
                _orderState.OpenOrder(this);
        }

        public bool CanShipment()
        {
            return _orderState.CanShipment(this);
        }

        public void Shipment()
        {
            if (CanShipment())
                _orderState.Shipment(this);
        }

        public bool CanStatusCheck()
        {
            return _orderState.CanStatusCheck(this);
        }

        public void StatusCheck()
        {
            if (CanStatusCheck())
                _orderState.StatusCheck(this);
        }

        public bool CanShippingMethod()
        {
            return _orderState.CanShippingMethod(this);
        }

        public void ShippingMethod()
        {
            if (CanShippingMethod())
                _orderState.ShippingMethod(this);
        }

        private void Change(IOrderState orderState)
        {
            _orderState = orderState;
        }
    }
}

