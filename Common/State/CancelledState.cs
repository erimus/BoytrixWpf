namespace Boytrix.Logic.Business.Common.State
{
   public  class CancelledState : IVmState
    {
       public bool CanStart(VmStateContext vm)
       {
           throw new System.NotImplementedException();
       }

       public void Start(VmStateContext vm)
       {
           throw new System.NotImplementedException();
       }

       public bool CanLogin(VmStateContext vm)
       {
           throw new System.NotImplementedException();
       }

       public void Login(VmStateContext vm)
       {
           throw new System.NotImplementedException();
       }

       public bool CanAdd(VmStateContext vm)
        {
            return true;
        }

        public void Add(VmStateContext vm)
        {
            vm.Change(new AddState());
        }

        public bool CanCancel(VmStateContext vm)
        {
            return false;
        }

        public void Cancel(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanEdit(VmStateContext vm)
        {
            return true;
        }

        public void Edit(VmStateContext vm)
        {
            vm.Change(new EditState());
        }

        public bool CanDelete(VmStateContext vm)
        {
            return false;
        }

        public void Delete(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanSelect(VmStateContext vm)
        {
            return false;
        }

        public void Select(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanSave(VmStateContext vm)
        {
            return false;
        }

        public void Save(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanCommit(VmStateContext vm)
        {
            return false;
        }

        public void Commit(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanReview(VmStateContext vm)
        {
            return false;
        }

        public void Review(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanRefresh(VmStateContext vm)
        {
            return false;
        }

        public void Refresh(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanValidate(VmStateContext vm)
        {
            return false;
        }

        public void Validate(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanView(VmStateContext vm)
        {
            return false;
        }

        public void View(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanSearch(VmStateContext vm)
        {
            return false;
        }

        public void Search(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanExit(VmStateContext vm)
        {
            return true;
        }

        public void Exit(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

       public void Display(VmStateContext vm)
       {
           throw new System.NotImplementedException();
       }

       public VmStatus Status
        {
            get {   return VmStatus.Cancelled;  }
        }


        public bool CanApprove(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public void Approve(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanReject(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public void Reject(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanResolve(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public void Resolve(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public bool CanIgnore(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

        public void Ignore(VmStateContext vm)
        {
            throw new System.NotImplementedException();
        }

       public bool CanDisplay(VmStateContext vm)
       {
           throw new System.NotImplementedException();
       }
    }
}
