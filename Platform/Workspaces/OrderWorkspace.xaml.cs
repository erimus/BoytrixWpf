using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Workspaces
{
    /// <summary>
    /// Interaction logic for AdminWorkspace.xaml
    /// </summary>
    public partial class OrderWorkspace : UserControl, IRegionMemberLifetime
    {
        public OrderWorkspace()
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
