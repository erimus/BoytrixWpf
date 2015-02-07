using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Views
{
    /// <summary>
    /// Interaction logic for AdminNavigator.xaml
    /// </summary>
    public partial class AdminNavigator : UserControl, IRegionMemberLifetime
    {
        public AdminNavigator()
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
