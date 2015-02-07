using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;

namespace Boytrix.Logic.Business.Common.ViewState
{
   
    public class ViewCycler : IViewCycler
    {

        private ViewNavigationService<PageDetails> _views;

        public ViewCycler(IList<PageDetails> viewsOpened)
        {
           _views= new ViewNavigationService<PageDetails>(viewsOpened);
        }
        public   bool CanGoPrevious()
        {
            return _views != null && (_views.CurrentPosition > 0 && _views.CurrentPosition < _views.Count);
        }
        public void GoPrevious()
        {
            if (CanGoPrevious())
            {
                _views.MovePrevious();
               
                if (CurrentPage != null)
                {
                    var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                    eventAggregator.GetEvent<NavigationMessageEvent>().Publish(new NavigationMessage(CurrentPage.PageTitle));

                }
            }
        }


        public bool CanGoNext()
        {
            //int index = current + 1;
            return _views != null && _views.CurrentPosition + 1 < _views.Count; ;
            //return true;
        }

        public void GoNext()
        {
            if (CanGoNext())
            {
                _views.MoveNext();
              
                
                if (CurrentPage != null)
                {
                    var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                    eventAggregator.GetEvent<NavigationMessageEvent>().Publish(new NavigationMessage(CurrentPage.PageTitle));
                }
            }
        }

        public void Add(PageDetails pageDegtails)
        {
                var i = _views.IndexOf(pageDegtails);
                _views.Add(pageDegtails);
                _views.MoveLast();
            
        }

        public void Remove(PageDetails pageDegtails)
        {
            _views.Remove(pageDegtails);
        
        }

        public PageDetails CurrentPage
        {
            get
            {
                return  _views.CurrentItem();
            }
        }

        public void Clear()
        {
            _views.Clear();
        }
    }
}
