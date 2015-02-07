using Boytrix.UI.WPF.Libraries.Platform.ViewModel;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for AddGroup.xaml
    /// </summary>
    public partial class ShippingMethodDetail 
    {
        public ShippingMethodDetail(ShippingMethodDetailViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

  
    }
}
