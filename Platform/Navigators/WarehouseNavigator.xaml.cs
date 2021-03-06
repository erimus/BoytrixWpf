﻿using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Boytrix.UI.WPF.Libraries.Platform.Navigators
{
    /// <summary>
    /// Interaction logic for OrderNavigator.xaml
    /// </summary>
    public partial class WarehouseNavigator : UserControl, IRegionMemberLifetime
    {
        public WarehouseNavigator()
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
