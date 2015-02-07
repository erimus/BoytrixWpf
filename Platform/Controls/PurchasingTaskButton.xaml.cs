using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;

namespace Boytrix.UI.WPF.Libraries.Platform.Controls
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class PurchasingTaskButton : UserControl
    {
        public PurchasingTaskButton(PurchasingTaskButtonViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
