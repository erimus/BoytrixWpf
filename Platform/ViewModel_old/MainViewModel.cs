using Boytrix.UI.Common.Utilities.Enums;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.Common.Utilities.Infrastructure;
using Boytrix.UI.WPF.Libraries.Base;
using Boytrix.UI.WPF.Libraries.Platform.ViewModel.Tasks;
using Boytrix.UI.WPF.Libraries.Platform.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public class MainViewModel:BindableBase
    {
        private EditedItems editedItems { get; set; }
        public FormModeArgs FormArgs { get; set; }
        public DelegateCommand<string> NewCollection { get; set; }
        public DelegateCommand<string> OpenCollection { get; set; }
        public DelegateCommand<string> SaveCollection { get; set; }
        public DelegateCommand<string> EditCollection { get; set; }
        public DelegateCommand<string> DeleteCollection { get; set; }
        public DelegateCommand<string> RefreshCollection { get; set; }
        public DelegateCommand<string> CommitCollection { get; set; }
        public DelegateCommand<string> ReviewCollection { get; set; }
        public DelegateCommand<string> ShowUserView { get; set; }
        public MainViewModel()
        {
            NewCollection = new DelegateCommand<string>(AddNew, CanAddNew);
            OpenCollection = new DelegateCommand<string>(View, CanView);
            SaveCollection = new DelegateCommand<string>(Save, CanSave);
            EditCollection = new DelegateCommand<string>(Edit, CanEdit);
            DeleteCollection = new DelegateCommand<string>(Delete, CanDelete);
            RefreshCollection = new DelegateCommand<string>(Refresh, CanRefresh);
            CommitCollection = new DelegateCommand<string>(Commit, CanCommit);
            ReviewCollection = new DelegateCommand<string>(Review, CanReview);
            ShowUserView = new DelegateCommand<string>(ShowUser, CanShowUsers);
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
           
            eventAggregator.GetEvent<FormModeArgsEvent>().Subscribe(UpdateMainViewForm);
        }

        private void ShowUser(string obj)
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();


            regionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion,
                                                     () => container.Resolve<UserAdmin>());
        }

        private bool CanShowUsers(string arg)
        {
            return true;
        }

        private void Review(string obj)
        {
            var msg = new ReviewModeArgs(); 
            msg.ViewName = FormArgs.ViewName;
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<ReviewModeArgsEvent>().Publish(msg);
        }

        private bool CanReview(string arg)
        {
            IsReviewVisible = FormArgs == null ? false :  FormArgs.HasPendingCommits == true;
            return IsReviewVisible;
        }

        private void Commit(string obj)
        {
            var msg = new CommitModeArgs();
            //msg.CanEnable = true;
            msg.ViewName = FormArgs.ViewName;


            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            eventAggregator.GetEvent<CommitModeArgsEvent>().Publish(msg);
        }

        private bool CanCommit(string arg)
        {
            IsCommitVisible = FormArgs == null ? false : FormArgs.ViewMode == FormMode.DELETEMODE | FormArgs.HasPendingCommits == true;
            return IsCommitVisible;
        }

        private bool CanSave(string arg)
        {
            IsSaveVisible = FormArgs == null ? false : FormArgs.CurrentVmOperation  != FormMode.SELECTMODE ;
            return FormArgs == null ? true : FormArgs.ViewMode == FormMode.EDITMODE | FormArgs.ViewMode == FormMode.ADDMODE | FormArgs.ViewMode == FormMode.DELETEMODE;
        }

        private void Save(string obj)
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var msg = new SaveModeArgs();
            msg.ViewName = FormArgs.ViewName;
            msg.FormState = FormArgs.ViewMode;
            eventAggregator.GetEvent<SaveModeArgsEvent>().Publish(msg);
        }

        private bool CanRefresh(string arg)
        {
            return true;
        }

        private void Refresh(string obj)
        {
            var msg = new RefreshModeArgs();
            //msg.CanEnable = true;
            msg.ViewName = FormArgs.ViewName;
           

            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            eventAggregator.GetEvent<RefreshModeArgsEvent>().Publish(msg);
            FormArgs.FormMode = FormMode.UNCHANGED ;
           
        }

        private void UpdateMainViewForm(FormModeArgs obj)
        {
             FormArgs = obj;
            if(obj.CurrentVmOperation==FormMode.SAVE || obj.CurrentVmOperation ==FormMode.COMMIT)
            {
                FormArgs.FormMode = FormMode.UNCHANGED;
            }
           
            UpdateButtonState();
        }

        private void Delete(string obj)
        {
            var msg = new DeleteModeArgs();
            //msg.CanEnable = true;
            msg.ViewName = FormArgs.ViewName;

            FormArgs.FormMode = FormMode.DELETEMODE;
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            eventAggregator.GetEvent<DeleteModeArgsEvent>().Publish(msg);

            
            
        }

        private bool CanDelete(string arg)
        {
            return FormArgs == null ? false : FormArgs.FormMode == FormMode.SELECTMODE 
                  | (FormArgs.CurrentVmOperation == FormMode.SELECTMODE & FormArgs.FormMode == FormMode.DELETEMODE);
             
        }

    

        private void UpdateButtonState()
        {
            NewCollection.RaiseCanExecuteChanged();
            OpenCollection.RaiseCanExecuteChanged();
            SaveCollection.RaiseCanExecuteChanged();
            EditCollection.RaiseCanExecuteChanged();
           DeleteCollection.RaiseCanExecuteChanged();
           CommitCollection.RaiseCanExecuteChanged();
           ReviewCollection.RaiseCanExecuteChanged();
        }

        private bool CanEdit(string arg)
        {
            return FormArgs == null ? false : FormArgs.FormMode == FormMode.SELECTMODE | (FormArgs.CurrentVmOperation == FormMode.SELECTMODE & FormArgs.FormMode == FormMode.EDITMODE);
        }

        private void Edit(string obj)
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var msg = new EditModeArgs();
            msg.ViewName = FormArgs.ViewName;
            eventAggregator.GetEvent<EditModeArgsEvent>().Publish(msg);

            FormArgs.FormMode = FormMode.EDITMODE;
         
            editedItems = new EditedItems();

        }

       

        private bool CanView(string arg)
        {
            return FormArgs == null ? false : FormArgs.FormMode == FormMode.SELECTMODE  | FormArgs.FormMode == FormMode.EDITMODE;
        }

        private void View(string obj)
        {
            
        }

        private bool CanAddNew(string arg)
        {
            return FormArgs == null ? false : FormArgs.FormMode == FormMode.SELECTMODE | FormArgs.FormMode == FormMode.UNCHANGED
                   | (FormArgs.CurrentVmOperation == FormMode.SELECTMODE & FormArgs.FormMode == FormMode.ADDMODE);
        }

        private void AddNew(string obj)
        {
          

            var msg = new AddModeArgs();
            msg.ViewName=FormArgs.ViewName ;
          
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<AddModeArgsEvent>().Publish(msg);

         
          
        }

        private bool isSaveVisible;
        public bool IsSaveVisible
        {
            get
            {
                return this.isSaveVisible;
            }

            set
            {

                if (isSaveVisible != value)
                    SetProperty(ref isSaveVisible, value);
            }
        }

        private bool isCommitVisible;
        public bool IsCommitVisible
        {
            get
            {
                return this.isCommitVisible;
            }

            set
            {
                if (isCommitVisible != value)
                    SetProperty(ref isCommitVisible, value);
            }
        }

        private bool isReviewVisible;
        public bool IsReviewVisible
        {
            get
            {
                return this.isReviewVisible;
            }

            set
            {
                if (isReviewVisible != value)
                    SetProperty(ref isReviewVisible, value);
            }
        }

       
    }
}
