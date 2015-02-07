using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for ShippingMethodGridView.xaml
    /// </summary>
    public partial class ShippingMethodGridView : UserControl
    {
        public ShippingMethodGridView(ShippingMethodViewModel shippingMethodViewModel)
        {
            InitializeComponent();
            DataContext = shippingMethodViewModel;
            //shippingMethodViewModel.LoadData();
        }
    }
}
