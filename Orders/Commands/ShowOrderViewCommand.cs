using System;
using System.Windows.Input;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.BoytrixModules.Order.Commands
{
    public class ShowOrderViewCommand : ICommand
    {
        private OrderTaskButtonViewModel m_ViewModel;
        public ShowOrderViewCommand(OrderTaskButtonViewModel viewModel)
        {
            m_ViewModel = viewModel;

         
        }
      
        public ICommand ShowShippingMethodView { get; set; }
        /// <summary>
        /// Whether the ShowOrderViewCommand is enabled.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Actions to take when CanExecute() changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the ShowOrderViewCommand
        /// </summary>
        public void Execute(object parameter)
        {
            // Initialize
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

            //pack://application:,,,/ReferencedAssembly;component/ResourceFile.xaml
            //pack://application:,,,/Boytrix.UI.Common.Utilities;component/Images/Basic/add.png
            // Show Ribbon Tab
            //var orderRibbonTab = new Uri("pack://application:,,,/Boytrix.UI.WPF.Libraries.Platform;component/RibbonTabs/OrderRibbonTab.xaml", UriKind.Absolute);
            //var orderRibbonTab = new Uri("OrderRibbonTab", UriKind.Relative);

            ////regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion,
            ////                                        () => container.Resolve<OrderRibbonTab>());
            //regionManager.RequestNavigate("RibbonRegion", orderRibbonTab);
            
            // Show Navigator
            var orderNavigator = new Uri("OrderNavigator", UriKind.Relative);
            regionManager.RequestNavigate("NavigatorRegion", orderNavigator, NavigationCompleted);
            
   

            //var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            //container.RegisterType<Object, OrderRibbonTab>("OrderRibbonTab");

            /* We invoke the NavigationCompleted() callback 
             * method in our final  navigation request. */

            //// Show Workspace
            //var OrderWorkspace = new Uri("OrderWorkspace", UriKind.Relative);
            //regionManager.RequestNavigate("WorkspaceRegion", OrderWorkspace, NavigationCompleted);
        }

       

        #region Private Methods

        /// <summary>
        /// Callback method invoked when navigation has completed.
        /// </summary>
        /// <param name="result">Provides information about the result of the navigation.</param>
        private void NavigationCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;

            // Publish ViewRequestedEvent
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Publish("Order");
        }

        #endregion
    }
}
