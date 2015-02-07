
using System;
using Boytrix.UI.WPF.Libraries.Platform.Controls;
using Boytrix.UI.WPF.Libraries.Platform.Navigators;
using Boytrix.UI.WPF.Libraries.Platform.RibbonTabs;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Stock
{
    public class StockModuleInit : IModule
    {
       
  
        public void Initialize()
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(InventoryTaskButton));

            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<Object, InventoryRibbonTab>("InventoryRibbonTab");
            container.RegisterType<Object, InventoryNavigator>("InventoryNavigator");
        }
    }
}
