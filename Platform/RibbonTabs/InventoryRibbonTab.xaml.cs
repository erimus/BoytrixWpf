﻿using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace Boytrix.UI.WPF.Libraries.Platform.RibbonTabs
{
    /// <summary>
    /// Interaction logic for ProductRibbonTab.xaml
    /// </summary>
    public partial class InventoryRibbonTab :   RibbonTab, IRegionMemberLifetime
    {
        public InventoryRibbonTab()
        {
            InitializeComponent();
        }

        public bool KeepAlive
        {
            get { return false; }
        }

    }
}
