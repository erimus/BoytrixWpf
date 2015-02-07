using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for AdminNavigator.xaml
    /// </summary>
    public partial class AdminRibbonTab  : RibbonTab, IRegionMemberLifetime
    {
        public AdminRibbonTab()
        {
            InitializeComponent();
        }

        public bool KeepAlive
        {
            get { return false; }
        }
    }
}
