using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigators
{
    /// <summary>
    /// Interaction logic for ProductNavigator.xaml
    /// </summary>
    public partial class ProductNavigator : UserControl, IRegionMemberLifetime
    {
        public ProductNavigator()
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
