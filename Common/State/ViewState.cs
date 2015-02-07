using System;
using Boytrix.Logic.Business.Common.ViewState;

namespace Boytrix.Logic.Business.Common.State
{
    public class ViewState : IVmState
    {
        public bool CanStart(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public void Start(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanLogin(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public void Login(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanAdd(VmStateContext vm)
        {
            return true;
        }

        public void Add(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanCancel(VmStateContext vm)
        {
            return true;
        }

        public void Cancel(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanEdit(VmStateContext vm)
        {
            return false;
        }

        public void Edit(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanDelete(VmStateContext vm)
        {
            return false;
        }

        public void Delete(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanSelect(VmStateContext vm)
        {
            return false;
        }

        public void Select(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanSave(VmStateContext vm)
        {
            return true;
        }

        public void Save(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanCommit(VmStateContext vm)
        {
            return true;
        }

        public void Commit(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanReview(VmStateContext vm)
        {
            return false;
        }

        public void Review(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanRefresh(VmStateContext vm)
        {
            return false;
        }

        public void Refresh(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanValidate(VmStateContext vm)
        {
            return true;
        }

        public void Validate(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanView(VmStateContext vm)
        {
            return true;
        }

        public void View(VmStateContext vm)
        {
            vm.ButtonVisibilty = new ButtonVisibiltyState
            {
                IsAddVisible = false,
                IsEditVisible = false,
                IsSaveVisible = false,
                IsDeleteVisible = false,
                IsCommitVisible = false,
                IsExitVisible = true,
                IsViewVisible = true,
                IsRefreshVisible = true,
                IsReviewVisible = false,
                IsSearchVisible = true,
                IsSearchEnabled = true
            };
        }

        public bool CanSearch(VmStateContext vm)
        {
            return false;
        }

        public void Search(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanExit(VmStateContext vm)
        {
            return true;
        }

        public void Exit(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public void Display(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public VmStatus Status
        {
            get { return VmStatus.Viewed; }
        }


        public bool CanApprove(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public void Approve(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanReject(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public void Reject(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanResolve(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public void Resolve(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanIgnore(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public void Ignore(VmStateContext vm)
        {
            throw new NotImplementedException();
        }

        public bool CanDisplay(VmStateContext vm)
        {
            throw new NotImplementedException();
        }
    }
}
