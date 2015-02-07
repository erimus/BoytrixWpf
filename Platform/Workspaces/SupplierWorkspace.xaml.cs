using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Workspaces
{
    /// <summary>
    /// Interaction logic for SupplierWorkspace.xaml
    /// </summary>
    public partial class SupplierWorkspace : UserControl, IRegionMemberLifetime
    {
        public SupplierWorkspace()
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
