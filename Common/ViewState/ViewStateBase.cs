using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boytrix.Logic.Business.Common.State;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public  class ViewBuilder
    {
        protected void BuildView(VmStateContext vwState)
        {
            var pageType = PageType.Display;
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var formArgs = container.Resolve<IViewService>();
            var mode = formArgs.ViewMode.Peek();
            PageTitle page = ViewManagement.GetPage(vwState.BackingClass, mode);

            if (!Exists())
            {
                var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                //This shows the view
                eventAggregator.GetEvent<NavigationMessageEvent>().Publish(new NavigationMessage(page));

                var pageDegtails = new PageDetails(vwState.BackingClass, page, pageType, mode);
                vwState.CurrentPageDetail = pageDegtails;
            }
        }

        private bool Exists()
        {

            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            var region = regionManager.Regions["WorkspaceRegion"];

            foreach (var view in region.Views)
            {
                if (view != null)
                {
                    //var v = view as T;
                    //if (v != null)
                    //{
                     
                    //    return true;
                    //}
                }
            }

            return false;
        }
    }
}
