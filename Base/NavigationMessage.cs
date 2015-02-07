using Boytrix.Logic.Business.Common.ViewState;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Boytrix.UI.WPF.Libraries.Base
{
   


    public class CloseView
    {
        public CloseView(PageTitle pageTitles)
        {
            PageTitles = pageTitles;
        }
        public PageTitle PageTitles
        {
            get;
            private set;
        }
    }

    public class CloseViewMessageEvent : PubSubEvent<CloseView> { }
}
