using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.Business.Common.SearchState.OrderState
{
    public class SearchDateState : IOrderSearch
    {
        public SearchDateState()
        {
            ControlVisibilty = new OrderSearchControlVisibiltyState
            {
                IsDateVisible = true,
                IsShippingMethodVisible = false,
                IsProductVisible = false,

            };
        }
        public OrderSearchControlVisibiltyState ControlVisibilty { get; private set; }

        public OrderSearchStatus Status
        {
            get { return OrderSearchStatus.Date; }
        }


        public void OrderRequest()
        {
            throw new NotImplementedException();
        }
    }
}
