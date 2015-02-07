using System;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public class DetailViewState : IViewState
    {
        public bool CanBeInHomePage(ViewContext vwState)
        {
            return false;
        }

        public void InHomeMode(ViewContext vwState)
        {
            throw new NotImplementedException();
        }

        public bool CanBeInDisplayPage(ViewContext vwState)
        {
            return false;
        }

        public void InDisplayMode(ViewContext vwState)
        {
            throw new NotImplementedException();
        }

        public bool CanBeInDetailPage(ViewContext vwState)
        {
            return true;
        }

        public void InDetailMode(ViewContext vwState)
        {
            var pageType = PageType.DataEntry;
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var formArgs = container.Resolve<IViewService>();
            var mode = formArgs.ViewMode.Peek();
            PageTitle page = ViewManagement.GetPage(vwState.BackingClass, mode);

            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //This shows the view
            eventAggregator.GetEvent<NavigationMessageEvent>().Publish(new NavigationMessage(page));

            var pageDegtails = new PageDetails(vwState.BackingClass, page, pageType, mode);
            vwState.CurrentPageDetail = pageDegtails;
        }

        public ViewStatus Status
        {
            get { return ViewStatus.Detail; }
        }


        public ButtonVisibiltyState ButtonVisibilty { get; private set; }
    }
}
