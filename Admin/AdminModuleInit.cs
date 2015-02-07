

//using Boytrix.Logic.Business.Common;
//using Boytrix.Logic.DataTransfer.Proxies.User;
//using Boytrix.Logic.DataTransfer.Repository;
//using Boytrix.Logic.Model.Classes.AdminData;
//using Boytrix.UI.Common.Utilities.Infrastructure;
//using Boytrix.UI.WPF.BoytrixModules.Admin.Controllers;
//using Boytrix.UI.WPF.BoytrixModules.Admin.DataServices;
//using Boytrix.UI.WPF.BoytrixModules.Admin.ViewModels;
//using Boytrix.UI.WPF.BoytrixModules.Admin.Views;
//using Boytrix.UI.WPF.BoytrixModules.Login.DataServices;
//using Boytrix.UI.WPF.Libraries.Platform.Controls;
//using BoytrixWpf;
//using Microsoft.Practices.Prism.Modularity;
//using Microsoft.Practices.Prism.Mvvm;
//using Microsoft.Practices.Prism.Regions;
//using Microsoft.Practices.ServiceLocation;
//using Microsoft.Practices.Unity;
//using Proxy;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;

//namespace Admin
//{
//    public class AdminModuleInit:IModule
//    {
//        private readonly IUnityContainer container;
//        private readonly IRegionManager regionManager;
//        private MainRegionController _mainRegionController;

//        public AdminModuleInit(IUnityContainer container, IRegionManager regionManager)
//        {
//            this.container = container;
//            this.regionManager = regionManager;
//        }
//        public void Initialize()
//        {
//            // Register the EmployeeDataService concrete type with the container.
//            // Change this to swap in another data service implementation.
//            this.container.RegisterType<IAdminDataService, AdminDataService>();
//            this.container.RegisterType<IAdminRepository, AdminRepository>();
//            this.container.RegisterType<IUserDataService, UserDataService>();
//            this.container.RegisterType<IUserRepository, UserRepository>();
//            this.container.RegisterType<IUserServiceClientData, UserServiceClientData>();
//            this.container.RegisterType<Proxy.IAdminServiceClientData, AdminServiceClientData>();

//            var shippingMethodViewModel = container.Resolve<ShippingMethodViewModel>();
//            ShippingMethodView myForm = new ShippingMethodView( shippingMethodViewModel);
//            // Register the existing object instance with the container
//            container.RegisterInstance<UserControl>(Boytrix.UI.Common.Utilities.Enums.SecurityPermissionEnum.SHIPPINGMETHODS.ToString(), myForm);
//          //  container.RegisterType<UserControl>(new InjectionConstructor(someInt, someString, someDouble));


//            //this.container.RegisterType<UserControl>("49");
            
//           //container.RegisterType<UserServiceClientData>(new InjectionFactory(c => new UserServiceClientData(), new HierarcicalLifetimeManager())


//            //this.regionManager.RegisterViewWithRegion(RegionNames.MainContentRegion,
//            //                                           () => this.container.Resolve<ShippingMethodView>());

//            //this.regionManager.RegisterViewWithRegion(RegionNames.MainContentRegion,
//            //                                          () => this.container.Resolve<Boytrix.UI.WPF.BoytrixModules.Login.Views.MainView>());



//            //this.regionManager.RegisterViewWithRegion(RegionNames.MainContentRegion,
//            //                                         () => this.container.Resolve<Boytrix.UI.WPF.Libraries.Platform.View.MainMenuView>());

//            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
//            regionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(AdminTaskButton));
           
//        }
//    }
//}
