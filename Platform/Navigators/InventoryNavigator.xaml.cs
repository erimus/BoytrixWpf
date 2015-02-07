using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigators
{
    /// <summary>
    /// Interaction logic for OrderNavigator.xaml
    /// </summary>
    public partial class InventoryNavigator : UserControl, IRegionMemberLifetime
    {
        public InventoryNavigator()
        {
            InitializeComponent();
        }


        #region IRegionMemberLifetime Members

        public bool KeepAlive
        {
            get { return false; }
        }

        #endregion
    }
}
