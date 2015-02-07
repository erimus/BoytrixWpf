
using System.Windows;

namespace BoytrixWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            BoytrixBootstrapper bootstrapper = new BoytrixBootstrapper();
            bootstrapper.Run();
        }
       

        /// <summary>
        /// The On Start up event
        /// </summary>
        /// <param name="e"> 
        /// The e parameter.
        /// </param>
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    // The boostrapper will create the Shell instance, so the App.xaml does not have a StartupUri.
        //    DesktopBootstrapper bootstrapper = new DesktopBootstrapper();

        //    try
        //    {
        //        bootstrapper.Run();
        //    }
        //    catch (ReflectionTypeLoadException rtlex)
        //    {
        //        string x = rtlex.Message;

        //        throw;
        //    }
        //    catch (ModuleTypeLoadingException mtlex)
        //    {
        //        string x = mtlex.Message;

        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        string x = ex.Message;

        //        throw;
        //    }
        //}
    }
}
