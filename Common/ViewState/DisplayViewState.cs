using System;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public class DisplayViewState : IViewState
    {
       

        public bool CanBeInHomePage(ViewContext vwState)
        {
            return true;
        }

        public void InHomeMode(ViewContext vwState)
        {
            throw new NotImplementedException();
        }

        public bool CanBeInDisplayPage(ViewContext vwState)
        {
            return true;
        }

        public void InDisplayMode(ViewContext vwState)
        {
            var pageType =  PageType.Display;
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

        public PageDetails CurrentPage { get; set; }

      


        public bool CanBeInDetailPage(ViewContext vwState)
        {
            return true;
        }

        public void InDetailMode(ViewContext vwState)
        {
            vwState.Change(new DetailViewState());
        }

        public ViewStatus Status
        {
            get { return ViewStatus.Display; }
        }

        public ButtonVisibiltyState ButtonVisibilty { get;  set; }
        public string BackingClass { get;  set; }



    }
}