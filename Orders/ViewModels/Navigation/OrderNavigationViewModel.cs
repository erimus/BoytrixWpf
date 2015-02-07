
using System;
using System.Windows.Input;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.State;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.UI.Common.Utilities;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.BoytrixModules.Order.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Navigation
{
    public class OrderNavigationViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        public OrderNavigationViewModel()
        {
            Initialize();
        }
        /// Loads the view for Module A.
        /// </summary>
        public ICommand ShowOrderView { get; set; }
        public ICommand ShowShippingMethodViewCommand { get; set; }
        
         public DelegateCommand<string> ShowOpenOrderViewCommand { get; set; }

         public bool KeepAlive
         {
             get { return true; }
         }

        private void Initialize()
        {
           
            var vw = new ViewService
            {
                CurrentVmOperation = FormMode.UNCHANGED,
                HasNoRecords = true,
                HasPendingCommits = false,
                IsDirty = false,
                TabSelectedIndex = 0


            };
            vw.ViewMode.Push(FormMode.UNCHANGED);
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterInstance<IViewService>(vw);
           
            IVmState vmState = new StartState();
            var vmContext = new VmStateContext(vmState);
            vmContext.StartMode();
            container.RegisterInstance<VmStateContext>(vmContext);



            ShowOrderView = new DelegateCommand<string>(OpenOrderView, CanOpenOrderView);

            ShowOpenOrderViewCommand = new DelegateCommand<string>(OpenOrderView, CanOpenOrderView);
            ShowShippingMethodViewCommand = new DelegateCommand<string>(ShowShippingMethodView, CanShowShippingMethodView);

               
        }

        private bool CanShowShippingMethodView(string arg)
        {
            return true;
        }

        private void ShowShippingMethodView(string obj)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            var crudRibbonTab = new Uri("CrudRibbonTab", UriKind.Relative);

            var shippingMethod = new Uri("ShippingMethod", UriKind.Relative);

            regionManager.RequestNavigate(RegionNames.WorkspaceRegion, shippingMethod);
            regionManager.RequestNavigate(RegionNames.RibbonRegion, crudRibbonTab);

           
        }

        private void OpenOrderView(string obj)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var orderRibbonTab = new Uri("OrderRibbonTab", UriKind.Relative);

          
                
                //PageType.DataEntry


            var openOrders = new Uri("OpenOrders", UriKind.Relative);

          

            var vw = container.Resolve<IViewService>();
            vw.ViewName = "OpenOrders";
            vw.ViewBackingClass = "Order";
            vw.ToolbarName = orderRibbonTab.ToString();

            regionManager.RequestNavigate(RegionNames.RibbonRegion, orderRibbonTab);
            regionManager.RequestNavigate(RegionNames.WorkspaceRegion, openOrders, NavigationCompleted);
            
          
        }

        private bool CanOpenOrderView(string arg)
        {
            return true;
        }

        public bool CanOpenForm(string text)
        {
            return !string.IsNullOrEmpty(text);
        }

        public void OpenForm(string text)
        {
           // var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //var msg = new OpenViewMessage();
            //msg.ViewName = text;
            //eventAggregator.GetEvent<OpenViewEvent>().Publish(msg);



            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

         
            var orderRibbonTab = new Uri("OrderRibbonTab", UriKind.Relative);


           

            var openOrders = new Uri("OpenOrders", UriKind.Relative);

            regionManager.RequestNavigate(RegionNames.WorkspaceRegion, openOrders);

            var msg = new NavigationParameters();
            msg.Add("ViewName", "OpenOrders");
            regionManager.RequestNavigate(RegionNames.RibbonRegion, orderRibbonTab, msg);
        }

        private void NavigationCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;


            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var msg = new OpenViewMessage();
            msg.ViewName = result.Context.Uri.ToString();
            eventAggregator.GetEvent<OpenViewEvent>().Publish(msg);



        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
           
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
