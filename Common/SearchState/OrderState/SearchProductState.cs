using System;

namespace Boytrix.Logic.Business.Common.SearchState.OrderState
{
    public class ProductSearchState : IOrderSearch
    {
        public ProductSearchState()
        {
            ControlVisibilty = new OrderSearchControlVisibiltyState
            {
                IsDateVisible = false,
                IsShippingMethodVisible = false,
                IsProductVisible = true,

            };
        }
        public OrderSearchControlVisibiltyState ControlVisibilty { get; private set; }

        public OrderSearchStatus Status
        {
            get { return OrderSearchStatus.Product; }
        }


        public void OrderRequest()
        {
            throw new NotImplementedException();
        }
    }
}
