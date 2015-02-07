
using System;
using System.Windows.Input;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Boytrix.UI.WPF.Libraries.Platform.Commands
{
    public class ShowWarehouseViewCommand:ICommand
    {
        private WarehouseTaskButtonViewModel m_ViewModel;
        public ShowWarehouseViewCommand(WarehouseTaskButtonViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }
        #region ICommand Members

        /// <summary>
        /// Whether the ShowAdminViewCommand is enabled.
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
        /// Executes the ShowAdminViewCommand
        /// </summary>
        public void Execute(object parameter)
        {
            // Initialize
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // Show Ribbon Tab
            var AdminRibbonTab = new Uri("WarehouseRibbonTab", UriKind.Relative);
            regionManager.RequestNavigate("RibbonRegion", AdminRibbonTab);

            // Show Navigator
            var AdminNavigator = new Uri("WarehouseNavigator", UriKind.Relative);
            regionManager.RequestNavigate("NavigatorRegion", AdminNavigator);

            /* We invoke the NavigationCompleted() callback 
             * method in our final  navigation request. */

            //// Show Workspace
            //var AdminWorkspace = new Uri("WarehouseWorkspace", UriKind.Relative);
            //regionManager.RequestNavigate("WorkspaceRegion", AdminWorkspace, NavigationCompleted);
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
            navigationCompletedEvent.Publish("Warehouse");
        }

        #endregion

    
    }
}
