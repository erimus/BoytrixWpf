using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace BoytrixWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
        private const string ModuleName = "Admin";
        private static readonly Uri LoginViewUri = new Uri("/ShippingMethodView", UriKind.Relative);
        public Shell(ShellViewModel vm)
        {
            InitializeComponent();
            Debug.WriteLine("Shell view initialized");
            DataContext = vm;
            
        }

        /// <summary>
        /// The Module Manager
        /// </summary>
        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        /// <summary>
        /// The Region Manager
        /// </summary>
        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        /// <summary>
        /// On Imports Satisfied event - NOT NEEDED!
        /// </summary>
        public void OnImportsSatisfied()
        {
            //this.ModuleManager.LoadModuleCompleted +=
            //   (s, e) =>
            //   {
            //       // todo: 01 - Navigation on when modules are loaded.
            //       // When using region navigation, be sure to use it consistently
            //       // to ensure you get proper journal behavior.  If we mixed
            //       // usage of adding views directly to regions, such as through
            //       // RegionManager.AddToRegion, and then use RegionManager.RequestNavigate,
            //       // we may not be able to navigate back correctly.
            //       // 
            //       // Here, we wait until the module we want to start with is
            //       // loaded and then navigate to the view we want to display
            //       // initially.     
            //       if (e.ModuleInfo.ModuleName == ModuleName)
            //       {
            //           this.RegionManager.RequestNavigate(RegionNames.MainContentRegion, LoginViewUri);
            //       }
            //   };
        }
    }
}
