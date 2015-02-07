using System.Windows.Controls;
using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Navigation;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;

//using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Navigation;
//using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Navigation;
//using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Navigation;
//using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Navigation;
//using Boytrix.UI.WPF.Libraries.Platform.ViewModel.Navigation;

namespace Boytrix.UI.WPF.BoytrixModules.Order.Views
{
    /// <summary>
    /// Interaction logic for OrderNavigator.xaml
    /// </summary>
    public partial class OrderNavigator : UserControl
    {
        public OrderNavigator(OrderNavigationViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

     

    }
}
