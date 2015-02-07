using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;

namespace Boytrix.UI.WPF.Libraries.Platform.Controls
{
    /// <summary>
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class SupplierTaskButton : UserControl
    {
        public SupplierTaskButton(SupplierTaskButtonViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
