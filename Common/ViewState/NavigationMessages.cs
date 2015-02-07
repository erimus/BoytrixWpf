using Microsoft.Practices.Prism.PubSubEvents;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public class NavigationMessage
    {
        public NavigationMessage(PageTitle pageTitles)
        {
            PageTitles = pageTitles;
        }
        public PageTitle PageTitles
        {
            get;
            private set;
        }
    }

    public class NavigationMessageEvent : PubSubEvent<NavigationMessage> { }
}
