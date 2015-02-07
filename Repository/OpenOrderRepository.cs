using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.SearchState.OrderState;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Repository;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.DataAccess.Repository
{
    public class OpenOrderRepository : RepositoryBase<Order>
    {
        public OpenOrderRepository(CrudHandler<Order> crudHandler) : base(crudHandler)
        {
        }

        public override void GetModelData(Action<object, EventHandler> completedAction)
        {
            string strAllocatedChk = "NULL";
            string strExportedChk = "NULL";
            string strFilterBy = "NULL";
            string strFilterByValue = "NUll";
            string strItemAllocatedChk = "NULL";
            string strFilterByDate = "NULL";
            string strFilterDateFrom = "NULL";
            string strFilterDateTo = "NULL";

            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

            var search = container.Resolve<SearchContext>();

            if (search.SearchCriterion.AllocatedOrders!=null)
            {
                strAllocatedChk = search.SearchCriterion.AllocatedOrders.ToString();
            }
            if (search.SearchCriterion.ExportedOrders!=null)
            {
                strExportedChk = search.SearchCriterion.ExportedOrders.ToString();
            }
            if (search.SearchCriterion.FilterBy != null)
            {
                strFilterBy = search.SearchCriterion.FilterBy.GetHashCode().ToString();
            }
            if (search.SearchCriterion.FilterValue!=null)
            {
                strFilterByValue = DB.SQuote(search.SearchCriterion.FilterValue.Trim());
            }
            if (search.SearchCriterion.AllocatedProduct != null)
            {
                strItemAllocatedChk = search.SearchCriterion.AllocatedProduct.ToString();
            }
            if (search.SearchCriterion.FilterDateBy != null)
            {
                strFilterByDate = search.SearchCriterion.FilterDateBy.GetHashCode().ToString();
                strFilterDateFrom = DB.SQuote(search.SearchCriterion.FilterDateFrom.ToString("yyyy/MM/dd"));
                strFilterDateTo = DB.SQuote(search.SearchCriterion.FilterDateTo.ToString("yyyy/MM/dd"));
            }

            Dictionary<string, object> paramList = new Dictionary<string, object>
            {
                {"Allocated",strAllocatedChk},
                {"Exported", strExportedChk},
                {"FilterBy", strFilterBy},
                {"FilterByValue", strFilterByValue},
                {"ItemAllocated",strItemAllocatedChk},
                {"FilterByDate", strFilterByDate},
                {"FilterDateFrom", strFilterDateFrom},
                {"FilterDateTo", strFilterDateTo}
            };



            //string strFunName = GetShipmentOnly ? "OpenOrderShipments_Search" : "OpenOrders_Search";
            //string strFunName = "[dbo].[OpenOrderShipments_Search]";
            //String strCmd = String.Format("exec {0} {1},{2},{3},{4},{5},{6},{7},{8}", strFunName, strAllocatedChk, strExportedChk, strFilterBy, strFilterByValue, strItemAllocatedChk, strFilterByDate, strFilterDateFrom, strFilterDateTo);



            //Dictionary<string, object> paramList = new Dictionary<string, object>
            //{
            //    {"Allocated", search.SearchCriterion.AllocatedOrders},
            //    {"Exported", search.SearchCriterion.ExportedOrders},
            //    {"FilterBy", search.SearchCriterion.FilterDateBy},
            //    {"FilterByValue", search.SearchCriterion.FilterValue},
            //    {"ItemAllocated", search.SearchCriterion.AllocatedProduct},
            //    {"FilterByDate", search.SearchCriterion.FilterDateBy},
            //    {"FilterDateFrom", search.SearchCriterion.FilterDateFrom},
            //    {"FilterDateTo", search.SearchCriterion.FilterDateTo}
            //};



            base.SearchDbWithSp("[dbo].[OpenOrderShipments_Search]", "Order", paramList, o =>
            {

            });

            // (@Allocated bit,@Exported bit,@FilterBy int,@FilterByValue nvarchar(255), @ItemAllocated bit, @FilterByDate int, @FilterDateFrom datetime, @FilterDateTo datetime)

        }
    }
}
