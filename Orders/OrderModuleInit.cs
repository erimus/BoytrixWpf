using System;
using Boytrix.UI.WPF.BoytrixModules.Order.Views;
using Boytrix.UI.WPF.BoytrixModules.Order.Views.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using OrderRibbonTab = Boytrix.UI.WPF.BoytrixModules.Order.Views.OrderRibbonTab;
using Boytrix.UI.WPF.Libraries.Platform.RibbonTabs;

//using OrderRibbonTab = Boytrix.UI.WPF.BoytrixModules.Order.Views.OrderRibbonTab;

namespace Boytrix.UI.WPF.BoytrixModules.Order
{
    public class OrderModuleInit : IModule
    {
      
         public void Initialize()
         {
             var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
             regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(OrderTaskButton));
             // Register other view objects with DI Container (Unity)
             var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
             container.RegisterType<Object, OrderRibbonTab>("OrderRibbonTab");
             container.RegisterType<Object, OrderNavigator>("OrderNavigator");
             container.RegisterType<object, OpenOrders>("OpenOrders");
             container.RegisterType<object, ShippingMethodGridView>("ShippingMethod");
             container.RegisterType<object, CrudRibbonTab>("CrudRibbonTab");
            // container.RegisterType<Object, ModuleBWorkspace>("ModuleBWorkspace");

             
           
         }
    }
}
