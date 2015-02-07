using Boytrix.UI.WPF.BoytrixModules.Order.ViewModels;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Boytrix.UI.WPF.BoytrixModules.Order.Views
{
    /// <summary>
    /// Interaction logic for ProductRibbonTab.xaml
    /// </summary>
    public partial class OrderRibbonTab : RibbonTab, IRegionMemberLifetime, IActiveAware
    {
        public OrderRibbonTab(SearchViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        public bool KeepAlive
        {
            get { return true; }
        }

        private bool _IsActive = true;
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
                //if (value)
                //    OnActivate();
                //else
                //    OnDeactivate();
            }
        }

        public event System.EventHandler IsActiveChanged;
    }
}
