﻿using System;
using System.Windows.Input;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Boytrix.UI.WPF.Libraries.Platform.Commands
{
    public class ShowInventoryViewCommand : ICommand
    {
        private InventoryTaskButtonViewModel m_ViewModel;
       public ShowInventoryViewCommand(InventoryTaskButtonViewModel viewModel)
       {
           m_ViewModel = viewModel;
       }

       #region ICommand Members

       /// <summary>
       /// Whether the ShowProductViewCommand is enabled.
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
       /// Executes the ShowProductViewCommand
       /// </summary>
       public void Execute(object parameter)
       {
           // Initialize
           var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

           // Show Ribbon Tab
           var InventoryRibbonTab = new Uri("InventoryRibbonTab", UriKind.Relative);
           regionManager.RequestNavigate("RibbonRegion", InventoryRibbonTab);

           // Show Navigator
           var InventoryNavigator = new Uri("InventoryNavigator", UriKind.Relative);
           regionManager.RequestNavigate("NavigatorRegion", InventoryNavigator);

           /* We invoke the NavigationCompleted() callback 
            * method in our final  navigation request. */

           //// Show Workspace
           //var ProductWorkspace = new Uri("InventoryWorkspace", UriKind.Relative);
           //regionManager.RequestNavigate("WorkspaceRegion", ProductWorkspace, NavigationCompleted);
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
           navigationCompletedEvent.Publish("Inventory");
       }

       #endregion
    }
}
