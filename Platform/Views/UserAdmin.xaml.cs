using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for UserAdmin.xaml
    /// </summary>
    public partial class UserAdmin : UserControl
    {
        public UserAdmin(UserAdminViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
