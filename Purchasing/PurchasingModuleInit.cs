﻿using System;
using Boytrix.UI.WPF.Libraries.Platform.Controls;
using Boytrix.UI.WPF.Libraries.Platform.Navigators;
using Boytrix.UI.WPF.Libraries.Platform.RibbonTabs;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.BoytrixModules.Purchasing
{
    public class PurchasingModuleInit : IModule
    {
            
        public void Initialize()
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
           regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(PurchasingTaskButton));

           // Register other view objects with DI Container (Unity)
           var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
           container.RegisterType<Object, PurchasingRibbonTab>("PurchasingRibbonTab");
           container.RegisterType<Object, PurchasingNavigator>("PurchasingNavigator");
         

        }
    }
}
