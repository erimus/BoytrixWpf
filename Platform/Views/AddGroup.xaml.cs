using System.Windows.Controls;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for AddGroup.xaml
    /// </summary>
    public partial class AddGroup 
    {
        public AddGroup(AddEditUserGroupViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

  
    }
}
