using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;

namespace Boytrix.UI.WPF.Libraries.Platform.Controls
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductTaskButton : UserControl
    {
        public ProductTaskButton(ProductTaskButtonViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
