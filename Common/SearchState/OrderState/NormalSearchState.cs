using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.Business.Common.SearchState.OrderState
{
    public class NormalSearchState:IOrderSearch
    {
        public NormalSearchState()
        {
            ControlVisibilty = new OrderSearchControlVisibiltyState
            {
                IsDateVisible = false,
                IsShippingMethodVisible = false,
                IsProductVisible = false,
              
            };
        }
        public OrderSearchControlVisibiltyState ControlVisibilty { get; private set; }
        

        public OrderSearchStatus Status
        {
            get { return OrderSearchStatus.Normal; }
        }

        public void OrderRequest()
        {
            throw new NotImplementedException();
        }
    }
}
