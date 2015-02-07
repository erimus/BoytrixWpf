using System;
using System.Collections.Generic;
using Boytrix.Logic.Business.Common.State;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public enum ViewStatus
    {
        Home,
        Display,
        Detail
    }

    public interface IViewState
    {
        bool CanBeInHomePage(ViewContext vwState);
        void InHomeMode(ViewContext vwState);      

        bool CanBeInDisplayPage(ViewContext vwState);
        void InDisplayMode(ViewContext vwState);
        bool CanBeInDetailPage(ViewContext vwState);
        void InDetailMode(ViewContext vwState);
        ViewStatus Status { get; }

        ButtonVisibiltyState ButtonVisibilty { get; }
    }

    public class ViewContext
    {
        private  IViewState _currentViewState;
        private VmStateContext _vmStateContext;
        public ViewContext(IViewState vwViewState)
        {
         
            _currentViewState = vwViewState;
            //ButtonVisibilty = _vmStateContext.ButtonVisibilty;

        }
       
        public PageDetails CurrentPageDetail { get; set; }
    
        //public ViewNavigationService<PageDetails> Views { get; set; }

        public int MyBitWise { get; set; }
        public Guid MyGuid { get; set; }
        public PageTitle PageTitle { get; private set; }
       
        public PageType PageType { get; private set; }
        public DateTime CurrentDateTime { get; set; }

       
        
        public ViewStatus Status
        {
            get { return _currentViewState.Status; }
        }

        public bool CanBeInHomePage()
        {
            return _currentViewState.CanBeInHomePage(this);
        }

        public void InHomeMode()
        {
            if (CanBeInHomePage())
                _currentViewState.InHomeMode(this);
        }

        public bool CanBeInDisplayPage()
        {
            return _currentViewState.CanBeInDisplayPage(this);
        }

        public void InDisplayMode()
        {
            if (CanBeInDisplayPage())
                _currentViewState.InDisplayMode(this);
        }

        public bool CanBeInDetailPage()
        {
            return _currentViewState.CanBeInDetailPage(this);
        }

        public void InDetailMode()
        {
            if (CanBeInDetailPage())
                _currentViewState.InDetailMode(this);
        }

        public IVmState CurrentViewModelState { get; set; }
        public void Change(IViewState state)
        {
            _currentViewState = state;
        }

        public IViewState CurrentViewState
        {
            get
            {
                return _currentViewState;
            }
        }

        public string BackingClass { get; set; }
        public ButtonVisibiltyState ButtonVisibilty { get; private set; }
    }
}
