using System;
using System.Collections.Generic;
using Boytrix.Logic.Business.Common.State;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public class HomeViewState:IViewState 
    {
        //public HomeViewState()
        //{
        //    ButtonVisibilty = new ButtonVisibiltyState
        //    {
        //        IsAddVisible = false,

        //        IsEditVisible = false,
        //        IsSaveVisible = false,
        //        IsDeleteVisible = false,
        //        IsCommitVisible = false,
        //        IsExitVisible = true,

        //        IsViewVisible = false,
        //        IsRefreshVisible = false,
        //        IsReviewVisible = false,
        //    };
        //}

        public bool CanBeInHomePage(ViewContext vwState)
        {
            return true;
        }

        public void InHomeMode(ViewContext vwState)
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            
            var vw = new ViewService
            {
                CurrentVmOperation = FormMode.UNCHANGED,
                HasNoRecords = true,
                HasPendingCommits = false,
               


            };
            vw.ViewMode.Push(FormMode.UNCHANGED);
            container.RegisterInstance<IViewService>(vw);

           // var CurrentPage = new PageDetails(null, PageTitle.HomePage, PageType.Start, FormMode.UNCHANGED, 0);
            //ButtonVisibilty = CurrentPage.ButtonVisibilty;

            //var lst = new List<PageDetails>();


            //Views = new ViewNavigationService<PageDetails>(lst);
           
        }

        public bool CanBeInDisplayPage(ViewContext vwState)
        {
            return true ;
        }

        public void InDisplayMode(ViewContext vwState)
        {
            vwState.Change(new DisplayViewState());
        }

        public bool CanBeInDetailPage(ViewContext vwState)
        {
            return false;
        }

        public void InDetailMode(ViewContext vwState)
        {
            throw new NotImplementedException();
        }

        public ViewStatus Status
        {
            get { return ViewStatus.Home; }
        }

        public ButtonVisibiltyState ButtonVisibilty {  get; private set; }

       
        public string BackingClass { get;  set; }
    }
}
