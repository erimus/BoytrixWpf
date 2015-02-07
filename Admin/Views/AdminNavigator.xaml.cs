using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Boytrix.UI.WPF.BoytrixModules.Admin.Views
{
    /// <summary>
    /// Interaction logic for AdminNavigator.xaml
    /// </summary>
    public partial class AdminNavigator :   RibbonTab, IRegionMemberLifetime
    {
        public AdminNavigator()
        {
            InitializeComponent();
        }

        public bool KeepAlive
        {
            get { return false; }
        }
    }
}
