using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Boytrix.UI.WPF.Libraries.Platform.RibbonTabs
{
    /// <summary>
    /// Interaction logic for ProductRibbonTab.xaml
    /// </summary>
    public partial class OrderRibbonTab :   RibbonTab, IRegionMemberLifetime
    {
        public OrderRibbonTab()
        {
            InitializeComponent();
        }

        public bool KeepAlive
        {
            get { return false; }
        }

    }
}
