
using System.ComponentModel;
using System.Windows;
using Boytrix.UI.WPF.Libraries.Platform.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace BoytrixWpf
{
    public class BoytrixBootstrapper : UnityBootstrapper
    {

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var moduleCatalog = new DirectoryModuleCatalog();
            moduleCatalog.ModulePath = @".\Modules";
            return moduleCatalog;
        }
      
        //protected override void ConfigureModuleCatalog()
        //{
        //    base.ConfigureModuleCatalog();

        //    ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
        //    moduleCatalog.AddModule(typeof(Admin.ModuleInit));
        //    moduleCatalog.AddModule(typeof(Orders.ModuleInit));
        //}

        //protected override void ConfigureContainer()
        //{
        //    base.ConfigureContainer();

        //    this.RegisterTypeIfMissing(typeof(IUserDataService), typeof(UserDataService), true);
        //    //this.Container.RegisterType<IUserDataService, UserDataService>();
        //}


        //protected virtual void ConfigureContainer()
        //{
        //    if (useDefaultConfiguration)
        //    {
        //        RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true);
        //        RegisterTypeIfMissing(typeof(IModuleInitializer), typeof(ModuleInitializer), true);
        //        RegisterTypeIfMissing(typeof(IModuleManager), typeof(ModuleManager), true);
        //        RegisterTypeIfMissing(typeof(RegionAdapterMappings), typeof(RegionAdapterMappings), true);
        //        RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
        //        RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);
        //        RegisterTypeIfMissing(typeof(IRegionViewRegistry), typeof(RegionViewRegistry), true);
        //        RegisterTypeIfMissing(typeof(IRegionBehaviorFactory), typeof(RegionBehaviorFactory), true);
        //        RegisterTypeIfMissing(typeof(IRegionNavigationJournalEntry), typeof(RegionNavigationJournalEntry), false);
        //        RegisterTypeIfMissing(typeof(IRegionNavigationJournal), typeof(RegionNavigationJournal), false);
        //        RegisterTypeIfMissing(typeof(IRegionNavigationService), typeof(RegionNavigationService), false);
        //        RegisterTypeIfMissing(typeof(IRegionNavigationContentLoader), typeof(UnityRegionNavigationContentLoader), true);

        //    }

        //}

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            MainView view = Container.TryResolve<MainView>();
            //UserDataService v=this.Container.TryResolve<UserDataService>();
         
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
           
            App.Current.MainWindow.Show();
        }
    }
}
