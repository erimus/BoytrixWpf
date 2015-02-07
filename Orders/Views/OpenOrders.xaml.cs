using System.Windows.Controls;
using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels;

namespace Boytrix.UI.WPF.BoytrixModules.Order.Views
{
    /// <summary>
    /// Interaction logic for OpenOrders.xaml
    /// </summary>
    public partial class OpenOrders : UserControl
    {
        public OpenOrders(OpenOrdersViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
