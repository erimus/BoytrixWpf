//using Boytrix.UI.WPF.Libraries.Platform.ViewModel.Navigation;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigators
{
    /// <summary>
    /// Interaction logic for OrderNavigator.xaml
    /// </summary>
    public partial class OrderNavigator : UserControl, IRegionMemberLifetime
    {
        //public OrderNavigator(OrderNavigationViewModel vm)
        //{
        //    InitializeComponent();
        //    this.DataContext = vm;
        //}
        public OrderNavigator()
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
