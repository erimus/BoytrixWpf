using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;

namespace Boytrix.UI.WPF.Libraries.Platform.Controls
{
    /// <summary>
    /// Interaction logic for AdminTaskButton.xaml
    /// </summary>
    public partial class WarehouseTaskButton : UserControl
    {
        public WarehouseTaskButton(WarehouseTaskButtonViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
