﻿using System;
using Boytrix.UI.WPF.Libraries.Platform.Controls;
using Boytrix.UI.WPF.Libraries.Platform.Navigators;
using Boytrix.UI.WPF.Libraries.Platform.RibbonTabs;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.BoytrixModules.Supplier
{
    public class SupplierModuleInit : IModule
    {
   
       
        public void Initialize()
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(SupplierTaskButton));
            // Register other view objects with DI Container (Unity)
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterType<Object, SupplierRibbonTab>("SupplierRibbonTab");
            container.RegisterType<Object, SupplierNavigator>("SupplierNavigator");
        }
    }
}
