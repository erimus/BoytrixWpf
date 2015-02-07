using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Repository;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Base;
using Boytrix.UI.WPF.Libraries.Platform.Navigation;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;
using MvvmValidation;


namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public abstract class DetailViewModelBase<T> : BindableBase    where T : class

    {
        private IUnityContainer containerFactory;
        private IEventAggregator eventAggregator;
        protected IUnityContainer container;
        protected IViewService ViewService;
        protected ValidationHelper Validator { get; private set; }
        public DetailViewModelBase(IEventAggregator eventAggregator, IUnityContainer container,IViewService viewService)
        {
            this.eventAggregator = eventAggregator;
            this.container = container;
           
            this.ViewService = viewService;

            containerFactory = container.CreateChildContainer();

            Validator = new ValidationHelper();
            Validator.ResultChanged += OnValidationResultChanged;

            eventAggregator.GetEvent<RecordMoveFirstEvent>().Subscribe(RecordMoveFirstEventHandler);
            eventAggregator.GetEvent<RecordMoveNextEvent>().Subscribe(RecordMoveNextEventHandler);
            eventAggregator.GetEvent<RecordMovePreviousEvent>().Subscribe(RecordMovePreviousEventHandler);
            eventAggregator.GetEvent<RecordMoveLastEvent>().Subscribe(RecordMoveLastEventHandler);


         

            
            eventAggregator.GetEvent<AddModeArgsEvent>().Subscribe(AddToCollection);
            eventAggregator.GetEvent<EditModeArgsEvent>().Subscribe(EditCollection);
            eventAggregator.GetEvent<DeleteModeArgsEvent>().Subscribe(DeleteFromCollection);
            eventAggregator.GetEvent<SaveModeArgsEvent>().Subscribe(SaveCollection);
           // eventAggregator.GetEvent<CommitModeArgsEvent>().Subscribe(CommitCollection);
            eventAggregator.GetEvent<ClearViewControlsEvent>().Subscribe(ClearControls);

            eventAggregator.GetEvent<CloseViewEvent>().Subscribe(OnCloseView);

            //eventAggregator.GetEvent<RefreshModeArgsEvent>().Subscribe(RefreshToCollection);
           
           // eventAggregator.GetEvent<ReviewModeArgsEvent>().Subscribe(ReviewCollection);
            //eventAggregator.GetEvent<SearchModeArgsEvent>().Subscribe(DoSearchDb);


            if (viewService.ViewMode.Peek() == FormMode.ADDMODE)
            {
                IsReadOnly = false;
                CreateNewRow();

          
            }

            //viewService.ViewMode.Push(FormMode.WIP);
        }



        private void OnCloseView(CloseViewMessage obj)
        {
            this.Dispose();
        }

        private void ClearControls(ClearViewControls obj)
        {
            SelectedItem = null;
            var item = CreateNewITem();

            SelectedItem = item;

            

        }

        private void OnValidationResultChanged(object sender, ValidationResultChangedEventArgs e)
        {
            // Get current state of the validation
            ValidationResult validationResult = Validator.GetResult();

            UpdateValidationSummary(validationResult);
        }
        private void UpdateValidationSummary(ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;
            ValidationErrorsString = validationResult.ToString();
        }
    
        private void CreateNewRow()
        {
           
         
            var data = CreateNewCollection();
            VmData = new RecordNavigationService<T>(data);
           
            AddToCollection(null);
            ViewService.HasNoRecords = !VmData.Any();

        }

        private void RecordMoveLastEventHandler(RecordMoveLast obj)
        {
            if (VmData != null)
            {
                VmData.MoveLast();
                SelectedItem = VmData.CurrentItem();
            }
        }

        private void RecordMovePreviousEventHandler(RecordMovePrevious obj)
        {
            if (VmData != null)
            {
                VmData.MovePrevious();
                SelectedItem = VmData.CurrentItem();
            }
        }

        private void RecordMoveNextEventHandler(RecordMoveNext obj)
        {
            if (VmData != null)
            {
                VmData.MoveNext();
                SelectedItem = VmData.CurrentItem();
            }
        }

        private void RecordMoveFirstEventHandler(RecordMoveFirst obj)
        {
            if (VmData != null)
            {
                VmData.MoveFirst();
                SelectedItem = VmData.CurrentItem();
            }
        }

        protected virtual void AddToCollection(AddModeArgs msg)
        {

            PreAddToCollection();
            var item = CreateNewITem();
            
            SelectedItem = item;
           


            IsReadOnly = false;

            PostAddToCollection();

            //this if to control the enable property of delete
            //Greater than one because add creates a new ro
            ViewService.HasNoRecords = VmData.Count==0;
        }
        
        protected void EditCollection(EditModeArgs obj)
        {
            
            var item = container.Resolve<T>();

            //var data = CreateNewCollection();
            //data.Add(item);
            //VmData = new ObservableCollection<T>(data);
            SelectedItem = item;
            //editedItems = new EditedItems();

            var data = container.Resolve<IEnumerable<T>>();

        }

        private void DeleteFromCollection(DeleteModeArgs obj)
        {

//Delete sql statement
            var mode = ViewService.ViewMode.Peek();
            if (mode == FormMode.SAVED | mode == FormMode.ADDMODE | mode == FormMode.EDITMODE)
            {

               
                //repository.DeleteUncomittedItems(SelectedItem, viewService.ViewMode.Peek());
                PreDeleteFromCollection();
                DeleteItemFromCollection();
                PostDeleteFromCollection();
                ViewService.HasNoRecords = !_vmData.Any();
                ViewService.IsDirty = _vmData.Any();
               
                //remove item from grid

                var msg = new VmOnDelete();
                msg.SetRow(SelectedItem);
                eventAggregator.GetEvent<VmOnDeleteEvent>().Publish(msg);
            }
            ClearControls(null);
            IsReadOnly = false;
        }

        //public ICommand OkCommand
        //{
        //    get
        //    {
        //        return Get(() => OkCommand, new DelegateCommand(
        //            () => DoSave(),
        //            () => !base.HasErrors));
        //    }
        //}
        private string validationErrorsString;
        public string ValidationErrorsString
        {
            get { return validationErrorsString; }
            private set
            {
                if (validationErrorsString != value)
                SetProperty(ref validationErrorsString, value);
            }
        }

        private bool? isValid;
        public bool? IsValid
        {
            get { return isValid; }
            private set
            {
                if (isValid != value)
                SetProperty(ref isValid, value);
            }
        }
        protected ValidationResult ValidateVm()
        {
            if (ViewService.ViewMode.Peek() != FormMode.VALIDATION)
            {
                ViewService.ViewMode.Push(FormMode.VALIDATION);
            }
            // Validate all (execute all validation rules)
            ValidationResult validationResult = Validator.ValidateAll();

        
            return validationResult;
        }
        protected virtual void GetValidationState()
        {
            // Get validation result for the entire object
            var validationResult = Validator.GetResult();

            //// Get validation result for a target
            //var firstNameValidationResult = Validator.GetResult(() => FirstName);
        }
        protected virtual void SaveCollection(SaveModeArgs obj)
        {
          
            obj.SetRow(_selectedItem); 
            if (ViewService.ViewMode.Peek() == FormMode.SAVED)
            {
                var mode = ViewService.ViewMode.Pop();
                if (mode==FormMode.ADDMODE )
                {
                    AddToCollection(null);
                }
                //if we save then add
         
                return;
            }
            ValidationResult validation = ValidateVm();
            if (validation.IsValid )
            {
               
                if (!DataStoreContainsDuplicates(obj))
                {
                    if (ViewService.ViewMode.Peek() == FormMode.VALIDATION)
                    {
                        ViewService.ViewMode.Pop();
                    }
                    IsReadOnly = true;
                    VmData.Add(_selectedItem);
                    DoSave(obj);
                    //drop wip and then add saved

                    if (ViewService.ViewMode.Peek() == FormMode.SAVED)
                    {
                        ViewService.ViewMode.Pop();
                        ViewService.IsDirty = true;
                    }

                    if (ViewService.ViewMode.Peek() == FormMode.WIP)
                    {
                        ViewService.ViewMode.Pop();
                    }

                   
                }

                else
                {
                    if (ViewService.ViewMode.Peek() != FormMode.WIP)
                    {
                        SendMessageBox("Duplicate Error Warning", "Duplicates not allowed");
                    }
                    IsReadOnly = false;
                }
            }
            else
            {

                    var msg = new ValidationArgs();
                    msg.Validation = validation.ErrorList;
                    eventAggregator.GetEvent<ValidationArgsEvent>().Publish(msg);
                
            }

        }

        private void DoSave(SaveModeArgs obj)
        {

            ViewService.ViewMode.Push(FormMode.SAVED);

            SaveOtherObjectsPriorToVmData(obj);
           
            SaveOtherObjectsPostVmData(obj);

           // viewService.HasPendingCommits = repository.HasPendingCommits();
            //container.RegisterInstance(SelectedItem, new ExternallyControlledLifetimeManager());
            //notify UI that new have a new row and to add it to our grid

            var msg = new VmOnSave(obj.FormState);
            msg.SetRow(obj.GetRow<T>());
            eventAggregator.GetEvent<VmOnSaveEvent>().Publish(msg);



        }
        //protected virtual void SaveVmData(SaveModeArgs obj)
        //{
        //    var row = obj.GetRow<T>();
        //   // repository.SaveNoCommit(obj.FormState, row);
        //}
        protected void SendMessageBox(string title, string message)
        {

            var msg = new NotificationMessage();
            msg.Title = title;
            msg.Message = message;

         
            eventAggregator.GetEvent<NotificationMessageEvent>().Publish(msg);
        }

        protected  T CreateNewITem()
        {

            return containerFactory.Resolve<T>();
           
        }

        protected ObservableCollection<T> CreateNewCollection()
        {
           
           return new DataService<T>();
        }


        private RecordNavigationService<T> _vmData;
        public RecordNavigationService<T> VmData
        {
            get
            {
                return _vmData;
            }   

            set
            {
                if (_vmData != value)
                    SetProperty(ref _vmData, value);
            }
        }




        private  T _selectedItem;
        public   T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != _selectedItem)
                {
                    SetProperty(ref _selectedItem, value);               
                    SelectRelatedRecords();
                }
            }
        }
        private bool isReadOnly;
        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }

            set
            {

                    SetProperty(ref isReadOnly, value);
                    IsEnabled = !isReadOnly;
                
            }
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return isEnabled; }

            set
            {
                if (isEnabled != value)
                    SetProperty(ref isEnabled, value);
            }
        }


        public void Dispose()
        {
            eventAggregator.GetEvent<RecordMoveFirstEvent>().Unsubscribe(RecordMoveFirstEventHandler);
            eventAggregator.GetEvent<RecordMoveNextEvent>().Unsubscribe(RecordMoveNextEventHandler);
            eventAggregator.GetEvent<RecordMovePreviousEvent>().Unsubscribe(RecordMovePreviousEventHandler);
            eventAggregator.GetEvent<RecordMoveLastEvent>().Unsubscribe(RecordMoveLastEventHandler);



            eventAggregator.GetEvent<AddModeArgsEvent>().Unsubscribe(AddToCollection);
            eventAggregator.GetEvent<EditModeArgsEvent>().Unsubscribe(EditCollection);
            eventAggregator.GetEvent<DeleteModeArgsEvent>().Unsubscribe(DeleteFromCollection);
            eventAggregator.GetEvent<SaveModeArgsEvent>().Unsubscribe(SaveCollection);
           // eventAggregator.GetEvent<CommitModeArgsEvent>().Unsubscribe(CommitCollection);
            eventAggregator.GetEvent<ClearViewControlsEvent>().Unsubscribe(ClearControls);

            eventAggregator.GetEvent<CloseViewEvent>().Unsubscribe(OnCloseView);
            GC.SuppressFinalize(this);
        }


        protected abstract bool DataStoreContainsDuplicates(SaveModeArgs obj);
        protected abstract void SaveOtherObjectsPriorToVmData(SaveModeArgs obj);


        protected abstract void SaveOtherObjectsPostVmData(SaveModeArgs obj);
        protected abstract bool VmDataContainsDuplicates();

        protected abstract void PreAddToCollection();
        protected abstract void PostAddToCollection();

        protected abstract void PreDeleteFromCollection();
        protected abstract void PostDeleteFromCollection();

        protected abstract void DeleteItemFromCollection();
        protected abstract void PreEditCollection();
        protected abstract void PostEditCollection();

        protected abstract void SelectRelatedRecords();
        protected abstract void ConfigureValidationRules();


    }
}




