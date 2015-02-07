
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.Libraries.Platform.Controllers
{ 
   
    public class MainRegionController
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
       // private readonly IAdminDataService dataService;

    }
}
