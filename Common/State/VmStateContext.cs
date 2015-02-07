using System;
using Boytrix.Logic.Business.Common.ViewState;

namespace Boytrix.Logic.Business.Common.State
{
    //public class VisibiltyState
    //{
    //    public bool IsAddVisible { get; set; }
    //    public bool IsEditVisible { get; set; }
    //    public bool IsSaveVisible { get; set; }
    //    public bool IsDeleteVisible { get; set; }
    //    public bool IsCommitVisible { get; set; }
    //    public bool IsExitVisible { get; set; }

    //    public bool IsViewVisible { get; set; }
    //    public bool IsRefreshVisible { get; set; }
    //    public bool IsReviewVisible { get; set; }

    //    //public bool IsLoggedInVisible { get; set; }
    //    //public bool IsSavedVisible { get; set; }
    //    //public bool IsViewVisible { get; set; }
    //    //public bool IsReviewVisible { get; set; }
    //    //public bool IsReviewVisible { get; set; }
    //}

    public class EnabledState
    {
        public bool IsAddEnabled { get; set; }
        public bool IsEditEnabled { get; set; }
        public bool IsSaveEnabled { get; set; }
        public bool IsDeleteEnabled { get; set; }
        public bool IsCommitEnabled { get; set; }
        public bool IsExitEnabled { get; set; }

        public bool IsViewEnabled { get; set; }
        public bool IsRefreshEnabled { get; set; }
        public bool IsReviewEnabled { get; set; }
    }
    public enum VmStatus
    {
        LoggedIn,
        Added,
        Edited,
        Cancelled,
        Deleted,
        Selected,
        Saved,
        Commited,
        Reviewed,
        Refreshed,
        Viewed,
        Validated,
        Searched,
        Exited,
        Approved,
        Rejected,
        Resolved,
        Ignored,
        Displayed,
        Started
    }
    public interface IVmState
    {
        bool CanStart(VmStateContext vm);
        void Start(VmStateContext vm);
        bool CanLogin(VmStateContext vm);
        void Login(VmStateContext vm);
        bool CanAdd(VmStateContext vm);
        void Add(VmStateContext vm);
        bool CanCancel(VmStateContext vm);
        void Cancel(VmStateContext vm);
        bool CanEdit(VmStateContext vm);
        void Edit(VmStateContext vm);
        bool CanDelete(VmStateContext vm);
        void Delete(VmStateContext vm);
        bool CanSelect(VmStateContext vm);
        void Select(VmStateContext vm);
        bool CanSave(VmStateContext vm);
        void Save(VmStateContext vm);
        bool CanCommit(VmStateContext vm);
        void Commit(VmStateContext vm);
        bool CanReview(VmStateContext vm);
        void Review(VmStateContext vm);
        bool CanRefresh(VmStateContext vm);
        void Refresh(VmStateContext vm);
        bool CanValidate(VmStateContext vm);
        void Validate(VmStateContext vm);
        //bool CanValidate(Vm vm);
        //void Validate(Vm vm);
        bool CanView(VmStateContext vm);
        void View(VmStateContext vm);
        bool CanSearch(VmStateContext vm);
        void Search(VmStateContext vm);
        bool CanExit(VmStateContext vm);
        void Exit(VmStateContext vm);
        bool CanApprove(VmStateContext vm);
         void Approve(VmStateContext vm);
         bool CanReject(VmStateContext vm);
        void Reject(VmStateContext vm);
         bool CanResolve(VmStateContext vm);
        void Resolve(VmStateContext vm);
         bool CanIgnore(VmStateContext vm);
        void Ignore(VmStateContext vm);
        bool CanDisplay(VmStateContext vm);
        void Display(VmStateContext vm);
        VmStatus Status { get; }
    }

    public class VmStateContext
    {
        private IVmState _vmState;

        public VmStateContext(IVmState vmState)
        {
            _vmState = vmState;
        }

        public ButtonVisibiltyState ButtonVisibilty { get; set; }
        public EnabledState EnabledState { get; set; }
        public DateTime VmDate { get; set; }
        public bool IsReadOnly { get; set; }

        public VmStatus Status
        {
            get { return _vmState.Status; }
        }

        public IVmState CurrentState
        {
            get { return _vmState; }
        }

        public string BackingClass { get; set; }
        public PageDetails CurrentPageDetail { get; set; }

        public bool CanLogin()
        {
            return _vmState.CanLogin(this);
        }
        public void Login()
        {
            if (CanLogin())
                _vmState.Login(this);
        }

        public bool CanCancel()
        {
            return _vmState.CanCancel(this);
        }
        public void Cancel()
        {
            if (CanCancel())
                _vmState.Cancel(this);
        }

        public bool CanDisplay()
        {
            return _vmState.CanDisplay(this);
        }
        public void Display()
        {
            if (CanDisplay())
                _vmState.Display(this);
        }


        public bool CanAdd()
        {
            return _vmState.CanAdd(this);
        }

        public void AddMode()
        {
            if (CanAdd())
                _vmState.Add(this);
        }

        public bool CanDelete()
        {
            return _vmState.CanDelete(this);
        }

        public void DeleteMode()
        {
            if (CanDelete())
                _vmState.Delete(this);
        }

        public bool CanEdit()
        {
            return _vmState.CanEdit(this);
        }

        public void EditMode()
        {
            if (CanEdit())
                _vmState.Edit(this);
        }

        public bool CanSelect()
        {
            return _vmState.CanSelect(this);
        }

        public void SelectMode()
        {
            if (CanSelect())
                _vmState.Select(this);
        }

        public bool CanSave()
        {
            return _vmState.CanSave(this);
        }

        public void SaveMode()
        {
            if (CanSave())
                _vmState.Save(this);
        }

        public bool CanCommit()
        {
            return _vmState.CanCommit(this);
        }

        public void CommitMode()
        {
            if (CanCommit())
                _vmState.Commit(this);
        }

        public bool CanReview()
        {
            return _vmState.CanReview(this);
        }

        public void ReviewMode()
        {
            if (CanReview())
                _vmState.Review(this);
        }

        public bool CanRefresh()
        {
            return _vmState.CanRefresh(this);
        }

        public void RefreshMode()
        {
            if (CanRefresh())
                _vmState.Refresh(this);
        }

        public bool CanView()
        {
            return _vmState.CanView(this);
        }

        public void ViewMode()
        {
            if (CanView())
                _vmState.View(this);
        }

        public bool CanSearch()
        {
            return _vmState.CanSearch(this);
        }

        public void SearchMode()
        {
            if (CanSearch())
                _vmState.Search(this);
        }

        public bool CanValidate()
        {
            return _vmState.CanValidate(this);
        }

        public void ValidateMode()
        {
            if (CanValidate())
                _vmState.Validate(this);
        }

        public bool CanExit()
        {
            return _vmState.CanExit(this);
        }

        public void ExitMode()
        {
            if (CanExit())
                _vmState.Exit(this);
        }

        public bool CanApprove()
        {
            return _vmState.CanApprove(this);
        }

        public void ApproveMode()
        {
            if (CanApprove())
                _vmState.Approve(this);
        }

        public bool CanReject()
        {
            return _vmState.CanReject(this);
        }

        public void RejectMode()
        {
            if (CanResolve())
                _vmState.Reject(this);
        }

        public bool CanResolve()
        {
            return _vmState.CanResolve(this);
        }

        public void ResolveMode()
        {
            if (CanResolve())
                _vmState.Resolve(this);
        }

        public bool CanIgnore()
        {
            return _vmState.CanIgnore(this);
        }

        public void IgnoreMode()
        {
            if (CanIgnore())
                _vmState.Ignore(this);
        }

        public bool CanStart()
        {
            return _vmState.CanStart(this);
        }

        public void StartMode()
        {
            if (CanStart())
                _vmState.Start(this);
        }
        public  void Change(IVmState vmState)
        {
            _vmState = vmState;
        }
    }
}
