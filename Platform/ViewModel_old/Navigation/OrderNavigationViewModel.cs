
//using Boytrix.UI.Common.Utilities.EventMessages;
//using Boytrix.UI.Common.Utilities.Infrastructure;
//using Microsoft.Practices.Prism.Commands;
//using Microsoft.Practices.Prism.Mvvm;
//using Microsoft.Practices.Prism.PubSubEvents;
//using Microsoft.Practices.Prism.Regions;
//using Microsoft.Practices.ServiceLocation;
//using Microsoft.Practices.Unity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel.Navigation
//{
//    public class OrderNavigationViewModel : BindableBase
//    {
//        public OrderNavigationViewModel()
//        {
//            this.Initialize();
//        }
//        /// Loads the view for Module A.
//        /// </summary>
//        public ICommand ShowOrderView { get; set; }


      
//        private void Initialize()
//        {

//            this.ShowOrderView = new DelegateCommand<string>(OpenForm, CanOpenForm);
//            //// Initialize command properties
//            //this.ShowOrderView = new ShowOrderViewCommand(this);

//            //// Initialize administrative properties
//            //this.IsChecked = false;

//            //// Subscribe to Composite Presentation Events
//            //var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
//            //var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
//            //navigationCompletedEvent.Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
//        }

//        public bool CanOpenForm(string text)
//        {
//            return !string.IsNullOrEmpty(text);
//        }

//        public void OpenForm(string text)
//        {
           
//            /* We invoke the NavigationCompleted() callback 
//             * method in our final  navigation request. */

//            // Show Workspace
//            var OrderWorkspace = new Uri(text+"View", UriKind.Relative);
//            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

//            var parameters = new NavigationParameters();
//            parameters.Add("View", text);

           
            
//            regionManager.RequestNavigate("WorkspaceRegion", OrderWorkspace, NavigationCompleted, parameters);

//        }

//        private void NavigationCompleted(NavigationResult result)
//        {
//            // Exit if navigation was not successful
//            if (result.Result != true) return;

//            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

//            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

//            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();


//            string id = result.Context.Parameters["View"].ToString();

//            // Broadcast an Open form event
//            var form = new OpenViewMessage();
//            form.ViewName = id;
//            eventAggregator.GetEvent<OpenViewEvent>().Publish(form);
          


//            //regionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion,
//            //                                           () => container.Resolve<ShippingMethodView>());
//        }

//    }
//}
