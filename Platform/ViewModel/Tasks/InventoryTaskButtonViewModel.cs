﻿using System;
using System.Windows.Input;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Platform.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
   public class InventoryTaskButtonViewModel : BindableBase, INavigationAware
    {
        #region Fields

        // Property variables
        private bool? p_IsChecked;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public InventoryTaskButtonViewModel()
        {
            Initialize();
        }
              #endregion

        #region INavigationAware Members

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Command Properties

        /// <summary>
        /// Loads the view for Module A.
        /// </summary>
        public ICommand ShowInventoryView { get; set; }   

        #endregion

        #region Inventory Properties

        /// <summary>
        /// Whether the button is checked (selected).
        /// </summary>
        public bool? IsChecked
        {
            get { return p_IsChecked; }

            set
            {
                if (p_IsChecked != value)
                    SetProperty(ref p_IsChecked, value);
                p_IsChecked = value;
                SetProperty(ref p_IsChecked, value);

            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Sets the IsChecked state of the Task Button when navigation is completed.
        /// </summary>
        /// <param name="publisher">The publisher of the event.</param>
        private void OnNavigationCompleted(string publisher)
        {
            // Exit if this module published the event
            if (publisher == "Inventory") return;

            // Otherwise, uncheck this button
            IsChecked = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        private void Initialize()
        {
            // Initialize command properties
            ShowInventoryView = new ShowInventoryViewCommand(this);

            // Initialize administrative properties
            IsChecked = false;

            // Subscribe to Composite Presentation Events
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
        }

        #endregion
    }
}
