

using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.UI.WPF.Libraries.Platform.Navigation;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Windows.Controls.Ribbon;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView :  RibbonWindow
    {
        private ViewSelector navigation;
        public MainView(MainViewModel vm, ViewSelector navigation)
        {
            InitializeComponent();
            DataContext = vm;


            this.navigation=navigation;
              var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

              eventAggregator.GetEvent<NavigationMessageEvent>().Subscribe(OnNavigation);
            
        }

        private void OnNavigation(NavigationMessage obj)
        {
            navigation.OnNavigation(obj);
        }
    }
    
}
