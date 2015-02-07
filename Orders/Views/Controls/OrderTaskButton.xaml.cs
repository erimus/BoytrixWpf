using System.Windows.Controls;
using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels.Tasks;

namespace Boytrix.UI.WPF.BoytrixModules.Order.Views.Controls
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class OrderTaskButton : UserControl
    {
        public OrderTaskButton(OrderTaskButtonViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        //public OrderTaskButton()
        //{
        //    InitializeComponent();
           
        //}
    }
}
