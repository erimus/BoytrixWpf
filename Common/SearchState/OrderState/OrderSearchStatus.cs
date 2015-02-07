using System;
using System.Collections.Generic;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.Business.Common.SearchState.OrderState
{
    public enum OrderSearchStatus
    {
        Normal,
        Date,
        Product,
    }

    public class OrderSearchControlVisibiltyState
    {
        //public bool IsByOrderVisible { get; set; }
        public bool IsDateVisible { get; set; }
        public bool IsShippingMethodVisible { get; set; }
        public bool IsProductVisible { get; set; }
    }

    public interface IOrderSearch
    {
        OrderSearchControlVisibiltyState ControlVisibilty { get; }
        //Void Change(IOrderSearch context);
        OrderSearchStatus Status { get; }
        void OrderRequest();
        //void CanByOrderId(OrderSearchContext searchContext);
        //void ByOrderId(OrderSearchContext searchContext);
    }

    public class SearchContext
    {
        private IOrderSearch _search;
        private string strAllocatedChk = "NULL";
        private string strExportedChk = "NULL";
        private string strFilterBy = "NULL";
        private string strFilterByValue = "NUll";
        private string strItemAllocatedChk = "NULL";
        private string strFilterByDate = "NULL";
        private string strFilterDateFrom = "NULL";
        private string strFilterDateTo = "NULL";
                
        public SearchContext(IOrderSearch search)
        {
            _search = search;
            SearchCriterion = new OrderSearchService();
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterInstance<SearchContext>(this);
            // eventAggregator.GetEvent<SearchModeArgsEvent>().Subscribe(DoSearch);
        }

        //private void DoSearch(string obj)
        //{
        //    var msg = new SearchModeArgs();
        //    msg.SearchValue = obj;
        //    eventAggregator.GetEvent<SearchModeArgsEvent>().Publish(msg);
        //    UpdateButtonState();
        //}

        public OrderSearchControlVisibiltyState ControlVisibilty
        {
            get { return _search.ControlVisibilty; }
        }

        public IOrderSearch CurrentState
        {
            get { return _search; }
            
        }
        public void Change(IOrderSearch search)
        {
            _search = search;
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterInstance<SearchContext>(this);
        }

        public OrderSearchStatus Status
        {
            get { return _search.Status; }
        }
        public OrderSearchService SearchCriterion { get; set; }
        //public void SearchCriteria(bool GetShipmentOnly)
        //{
        //    if (!string.IsNullOrEmpty(OrderSearchService.AllocatedOrders))
        //    {
        //        strAllocatedChk = OrderSearchService.AllocatedOrders.ToUpper() == "Y" ? "1" : "0";
        //    }
        //    if (!string.IsNullOrEmpty(OrderSearchService.ExportedOrders))
        //    {
        //        strExportedChk = (OrderSearchService.ExportedOrders.ToUpper() == "Y" ? "1" : "0");
        //    }
        //    if (!string.IsNullOrEmpty(OrderSearchService.FilterBy.ToString()))
        //    {
        //        strFilterBy = OrderSearchService.FilterBy.GetHashCode().ToString();
        //    }
        //    if (!string.IsNullOrEmpty(OrderSearchService.FilterValue))
        //    {
        //        strFilterByValue = DB.SQuote(OrderSearchService.FilterValue.Trim());
        //    }
        //    if (!string.IsNullOrEmpty(OrderSearchService.AllocatedProduct))
        //    {
        //        strItemAllocatedChk = (OrderSearchService.AllocatedProduct.ToUpper() == "Y" ? "1" : "0");
        //    }
        //    if (OrderSearchService.FilterDateBy != 0)
        //    {
        //        strFilterByDate = OrderSearchService.FilterDateBy.GetHashCode().ToString();
        //        strFilterDateFrom = DB.SQuote(OrderSearchService.FilterDateFrom.ToString("yyyy/MM/dd"));
        //        strFilterDateTo = DB.SQuote(OrderSearchService.FilterDateTo.ToString("yyyy/MM/dd"));
        //    }

        //    string strFunName = GetShipmentOnly ? "OpenOrderShipments_Search" : "OpenOrders_Search";
        //    String strCmd = String.Format("exec {0} {1},{2},{3},{4},{5},{6},{7},{8}", strFunName, strAllocatedChk, strExportedChk, strFilterBy, strFilterByValue, strItemAllocatedChk, strFilterByDate, strFilterDateFrom, strFilterDateTo);

        //}
    }
} 
