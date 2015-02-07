
using System;
using System.Windows.Input;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Boytrix.UI.WPF.BoytrixModules.Order.Commands
{
    public class ShowShippingMethodViewCommand : ICommand
    {
        private ShippingMethodViewModel m_ViewModel;
        public ShowShippingMethodViewCommand(ShippingMethodViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        #region ICommand Members

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

            // Show Ribbon Tab
            var OrderRibbonTab = new Uri("OrderRibbonTab", UriKind.Relative);
            regionManager.RequestNavigate("RibbonRegion", OrderRibbonTab);

            // Show Navigator
            var OrderNavigator = new Uri("OrderNavigator", UriKind.Relative);
            regionManager.RequestNavigate("NavigatorRegion", OrderNavigator);

            /* We invoke the NavigationCompleted() callback 
             * method in our final  navigation request. */

            //// Show Workspace
            //var OrderWorkspace = new Uri("OrderWorkspace", UriKind.Relative);
            //regionManager.RequestNavigate("WorkspaceRegion", OrderWorkspace, NavigationCompleted);
        }

        #endregion

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
