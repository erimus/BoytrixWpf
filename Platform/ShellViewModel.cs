using System.ComponentModel;
using Boytrix.UI.Common.Utilities;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Platform.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace BoytrixWpf
{
    public class ShellViewModel : INotifyPropertyChanged
    {
        private readonly IUnityContainer container;
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        //private readonly IUserDataService userDataService;
        public ShellViewModel(IUnityContainer container, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            // Initialize this ViewModel's commands.
            this.container = container;
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            //this.userDataService = userDataService;
            // Subscribe to an Event
            eventAggregator.GetEvent<CloseViewEvent>().Subscribe(ExitEventHandler);
            //container.RegisterType<IUserDataService,UserDataService>();
            //IUserDataService view = container.Resolve<IUserDataService>();
        }

    
        private void ExitEventHandler(CloseViewMessage obj)
        {

            var views = regionManager.Regions[RegionNames.MainContentRegion].Views;
            string viewToRemove = obj.ViewName;

            foreach (var view in views)
            {

                regionManager.Regions[RegionNames.MainContentRegion].Remove(view);
            }

            // views = this.regionManager.Regions[RegionNames.MainContentRegion].Views;
            // viewToRemove = obj.ViewName;

            // this.regionManager.Regions[RegionNames.MainContentRegion].f(view);

            //foreach (var view in views)
            //{

            //    this.regionManager.Regions[RegionNames.MainContentRegion].Remove(view);
            //}
            //this.regionManager.RegisterViewWithRegion(RegionNames.MainContentRegion, () => this.container.Resolve<MainView>());


            //if (viewToRemove != null)
            //{
            //    // We remove the view outside the foreach
            //    this.regionManager.Regions[RegionNames.MyRegion].Remove(viewToRemove);
            //}


            //var theView = regionManager.Regions[RegionNames.MainContentRegion].GetView(obj.ViewName);
            //regionManager.Regions[RegionNames.MainContentRegion].Remove(theView);

            regionManager.RegisterViewWithRegion(RegionNames.MainContentRegion, () => container.Resolve<MainView>());
        }

        #region ExitCommand

        public DelegateCommand<object> ExitCommand { get; private set; }

        private void AppExit(object commandArg)
        {
        }

        private bool CanAppExit(object commandArg)
        {
            return true;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
