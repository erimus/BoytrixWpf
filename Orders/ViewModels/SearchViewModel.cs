using System;
using System.Collections.Generic;
using System.Linq;
using Boytrix.Logic.Business.Common.SearchState;
using Boytrix.Logic.Business.Common.SearchState.OrderState;
using Microsoft.Practices.Prism.Mvvm;

namespace Boytrix.UI.WPF.BoytrixModules.Order.ViewModels
{
    public class SearchViewModel:BindableBase
    {
         private  Dictionary<string, string> _searchBy = new Dictionary<string, string>();

        private SearchContext _searchContext;
        public SearchViewModel()
        {
         

            ProductAllocated = new List<string>();
            OrderAllocated = new List<string>();
            OrderExported = new List<string>();
            //ByDate = new List<OrderScreenDateFilter>();
            ByDate = new List<OrderScreenDateFilter>();
            Warehouse = new List<string>();
            ShippingMethod  = new List<string>();

            SetUpSearchBy();
            SetupShippingMethod();
            SetupWarehouse();
            SetupOrderAllocated();
            SetupExported();
            SetupByDate();

            SearchBySelectedItem = _searchBy.FirstOrDefault(x => x.Key  == "ByOrderId");
            OrderAllocatedSelectedItem = _orderAllocated[0];
            OrderExportedSelectedItem = _orderExported[0];



        }

        //private void DoSearch(SearchModeArgs obj)
        //{
        //    string  s=
        //}

        private void SetupShippingMethod()
        {
              _shippingMethod.Add("AIR_UK");
                _shippingMethod.Add("expedited");
                _shippingMethod.Add("fr-collection");
                _shippingMethod.Add("freeStandard-am");
                _shippingMethod.Add("freeStandard-bp");
                _shippingMethod.Add("freeStandard-ma-de");
                _shippingMethod.Add("freeStandard-ma-es");
                _shippingMethod.Add("freeStandard-ma-fr");
                _shippingMethod.Add("freeStandard-ma-nl");
        }
        private void SetUpSearchBy()
        {
            _searchBy.Add("ByOrderId", "Order Id");
            _searchBy.Add("ByCustomerId", "Customer Id");
            _searchBy.Add("ByOrderDate", "Order Date");
            _searchBy.Add("ByCustomerEmail", "Customer Emaili");
            _searchBy.Add("ByShippingPostCode", "Shipping PostCode");
            _searchBy.Add("ByBillingPostCode", "Billing PostCode");
            _searchBy.Add("BySku", "Sku");
            _searchBy.Add("ByProductName", "Product Name");
            _searchBy.Add("ByImportDate", "Import Date");
            _searchBy.Add("ByExportDate", "Export Date");
            _searchBy.Add("ByShippingMethod", "Shipping Method");
        }

        private void SetupWarehouse()
        {
            _warehouse.Add("BULKSTORAGE_FROGMORE");
            _warehouse.Add("CARDIFF");
            _warehouse.Add("HEGA");
            _warehouse.Add("LOGWIN");
            _warehouse.Add("MA_EURX01");
            _warehouse.Add("MA_NONRX01");
            _warehouse.Add("MYPRESCRIPTIONS01");
            _warehouse.Add("RXOF");
            _warehouse.Add("TIMMERMANS");
        }

        private void SetupOrderAllocated()
        {
            _orderAllocated.Add("No Preference");
            _orderAllocated.Add("Yes");
            _orderAllocated.Add("No");
        }

        private void SetupExported()
        {
            _orderExported.Add("No Preference");
            _orderExported.Add("Yes");
            _orderExported.Add("No");
        }

        private void SetupByDate()
        {

            _byDate.Add(new OrderScreenDateFilter(1,"Equals"));
            _byDate.Add(new OrderScreenDateFilter(2,"Before"));
            _byDate.Add(new OrderScreenDateFilter(3,"After"));
            _byDate.Add(new OrderScreenDateFilter(4,"Between"));
        }
        public  Dictionary<string, string> SearchBy
        {
            get
            {
               
                return _searchBy;
            }
 
        }

        private KeyValuePair<string, string> _searchBySelectedItem;
        public KeyValuePair<string, string> SearchBySelectedItem
        {
            get
            {
                return _searchBySelectedItem;
            }
            set
            {
                if (!Equals(_searchBySelectedItem, value))
                {
                    SetProperty(ref _searchBySelectedItem, value);
                    SearchType();
                }



            }
        }

        private List<string> _productAllocated;
        public List<string> ProductAllocated
        {
            get
            {
               
                return _productAllocated;
            }
            set
            {
                if (!Equals(_productAllocated, value))
                {
                    SetProperty(ref _productAllocated, value);
                }

            }
        }



        private List<string> _orderAllocated;

        public List<string> OrderAllocated
        {
            get
            {
              
                return _orderAllocated;
            }
            set
            {
                if (!Equals(_orderAllocated, value))
                    SetProperty(ref _orderAllocated, value);

            }
        }

        private string _orderAllocatedSelectedItem;
        public string OrderAllocatedSelectedItem
        {
            get { return _orderAllocatedSelectedItem; }
            set
            {
                if (!Equals(_orderAllocatedSelectedItem, value))
                {
                    SetProperty(ref _orderAllocatedSelectedItem, value);
                    if (value == "Yes")
                    {
                        _searchContext.SearchCriterion.AllocatedOrders = 1;
                    }
                    else if (value == "No")
                    {
                        _searchContext.SearchCriterion.AllocatedOrders = 0;
                    }
                    else
                    {
                        _searchContext.SearchCriterion.AllocatedOrders = null;
                    }
                }
            }
        }

        

        private List<string> _orderExported;
        public List<string> OrderExported
        {
            get
            {
              
                return _orderExported;
            }
            set
            {
                if (!Equals(_orderExported, value))
                {
                    SetProperty(ref _orderExported, value);


                }
            }
        }

        private string _orderExportedSelectedItem;
        public string OrderExportedSelectedItem
        {
            get { return _orderExportedSelectedItem; }
            set
            {
                if (!Equals(_orderExportedSelectedItem, value))
                {
                    SetProperty(ref _orderExportedSelectedItem, value);
                    if (value == "Yes")
                    {
                        _searchContext.SearchCriterion.ExportedOrders = 1;
                    }
                    else if (value == "No")
                    {
                        _searchContext.SearchCriterion.ExportedOrders = 0;
                    }
                    else
                    {
                        _searchContext.SearchCriterion.ExportedOrders = null;
                    }
                   
                }
            }
        }



        private List<OrderScreenDateFilter> _byDate;
        public List<OrderScreenDateFilter> ByDate
        {
            get
            {
               
                return _byDate;
            }
            set
            {
                if (!Equals(_byDate, value))
                    SetProperty(ref _byDate, value);

            }
        }

        private OrderScreenDateFilter _byDateSelectedItem;
        public OrderScreenDateFilter ByDateSelectedItem
        {
            get { return _byDateSelectedItem; }
            set
            {
                if (!Equals(_byDateSelectedItem, value))
                {
                    SetProperty(ref _byDateSelectedItem, value);

                    _searchContext.SearchCriterion.FilterDateBy = (byte?) value.Id;
                }
            }
        }

        private List<string> _warehouse;
        public List<string> Warehouse
        {
            get
            {
               
                return _warehouse;
            }
            set
            {
                if (!Equals(_warehouse, value))
                {
                    SetProperty(ref _warehouse, value);
                    
                }

            }
        }

        private string _warehouseSelectedItem;
        public string WarehouseSelectedItem
        {
            get { return _warehouseSelectedItem; }
            set
            {
                if (!Equals(_warehouseSelectedItem, value))
                {
                    SetProperty(ref _warehouseSelectedItem, value);
                    _searchContext.SearchCriterion.WarehouseID = value;
                }
            }
        }

        private List<string> _shippingMethod;
        public List<string> ShippingMethod
        {
            get
            {
              
                return _shippingMethod;
            }
            set
            {
                if (!Equals(_shippingMethod, value))
                    SetProperty(ref _shippingMethod, value);

            }
        }

        private string _shippingMethodSelectedItem;
        public string ShippingMethodSelectedItem
        {
            get { return _shippingMethodSelectedItem; }
            set
            {
                if (!Equals(_shippingMethodSelectedItem, value))
                {
                    SetProperty(ref _shippingMethodSelectedItem, value);
                    _searchContext.SearchCriterion.ShippingMethod = value;
                }
            }
        }


        private void SearchType()
        {

            if (_searchBySelectedItem.Key == "ByOrderDate" | _searchBySelectedItem.Key == "ByImportDate"| _searchBySelectedItem.Key == "ByExportDate")
            {
                if (_searchContext.Status != OrderSearchStatus.Date)
                {
                    _searchContext.Change(new SearchDateState());
                }
            }

            else if(_searchBySelectedItem.Key == "BySku" | _searchBySelectedItem.Key == "ByProductName")
            {
                if (_searchContext.Status != OrderSearchStatus.Product)
                {
                    _searchContext.Change(new ProductSearchState());
                }
            }
        else
            {
                if (_searchContext==null)
                    _searchContext = new SearchContext(new NormalSearchState());
                    
                else if (_searchContext.Status != OrderSearchStatus.Normal)
                {
                    _searchContext.Change(new NormalSearchState());
                }

            }

            OnPropertyChanged("SearchContext");
        }

        public SearchContext SearchContext
        {
            get { return _searchContext; }
            set
            {
                if (!Equals(_searchContext, value))
                SetProperty(ref _searchContext, value);
            }
        }


    }
}
