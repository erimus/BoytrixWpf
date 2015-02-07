using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Repository;
using Boytrix.UI.Common.Utilities.EventMessages;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.Libraries.Base
{
    public abstract class VmBase<T> : BindableBase where T:class
    {
        public event EventHandler ItemSelectedEvent;
        protected FormMode FormState = FormMode.EDITMODE;
        protected StringBuilder SqlStatements = new StringBuilder();
        protected RepositoryBase<T> repository;
        private object _shippingMethodLock = new object();
       
        protected string m_modelName;

        public VmBase(RepositoryBase<T> repository)
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            ViewState = container.Resolve<IViewService>();
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

           
            this.repository = repository;
           
            eventAggregator.GetEvent<VmOnSaveEvent>().Subscribe(OnSaveEventHandler);
            eventAggregator.GetEvent<VmOnDeleteEvent>().Subscribe(OnDeleteEventHandler);

            //eventAggregator.GetEvent<AddModeArgsEvent>().Subscribe(AddToCollection);
            //eventAggregator.GetEvent<EditModeArgsEvent>().Subscribe(EditToCollection);
           
            //eventAggregator.GetEvent<SaveModeArgsEvent>().Subscribe(SaveToCollection);
            //eventAggregator.GetEvent<RefreshModeArgsEvent>().Subscribe(RefreshToCollection);
            //eventAggregator.GetEvent<CommitModeArgsEvent>().Subscribe(CommitCollection);


            eventAggregator.GetEvent<ReviewModeArgsEvent>().Subscribe(ReviewCollection);
            eventAggregator.GetEvent<SearchModeArgsEvent>().Subscribe(DoSearchDb);

            DoubleClickCommand = new DelegateCommand<object>(DoDoubleClickEdit, CanDoDoubleClickEdit);
         

            if (repository == null) throw new ArgumentNullException("repository");

            this.repository = repository;

           

           // LoadData();
            CanSelectItem = false;
            DefaultMode();
            IsActiveChanged += (o, e) =>
            {
                //Check if we have any pending changes
            };

            //var service = container.Resolve<IViewService>();
            //if (service.ViewMode.Peek()  == FormMode.ADDMODE)
            //{
            //    AddNewRow();
            //}
            //else if (service.ViewMode.Peek()  == FormMode.EDITMODE)
            //{
            //    EditRow();
            //} 

        }


        private void OnDeleteEventHandler(VmOnDelete obj)
        {

            VmData.Remove(obj.GetRow<T>());
            repository.DeleteUncomittedItems(obj.GetRow<T>(), ViewState.ViewMode.Peek());
            ViewState.HasPendingCommits = repository.HasPendingCommits();
        }
        protected virtual void OnSaveEventHandler(VmOnSave obj)
        {
           
            var data = obj.GetRow<T>();
            VmData.Add(data);
            SaveToRepository(obj);
            ViewState.HasPendingCommits = true;
        }

        public virtual void DoDoubleClickEdit(object obj)
        {
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            container.RegisterInstance<T>(SelectedItem);
            var msg = new DoubleClickArgs();
             var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
             eventAggregator.GetEvent<DoubleClickArgsEvent>().Publish(msg);
        }

        private bool CanDoDoubleClickEdit(object arg)
        {
            return _vmData.Any();
        }


        protected virtual  void SetViewModelData()
        {


            IEnumerable<T> data = repository.ViewModelData ;
            //ColView = CollectionViewSource.GetDefaultView(data);

            if (data != null)
            {
                VmData = new ObservableCollection<T>(repository.ViewModelData);



                BindingOperations.EnableCollectionSynchronization(VmData, _shippingMethodLock);
                //EditEventHandler();

                //  VmData.CollectionChanged += VmData_CollectionChanged;
            }
            else
                VmData = null;
        }

        private string _status;
        public string StatusMessage
        {
            get { return _status; }
            set
            {
                _status = value;
                SetProperty(ref _status, value);
            }
        }
        private double progress;
        public double Progress
        {
            get { return progress; }

            set
            {
                OnPropertyChanged("Progress");
                progress = value;
                OnPropertyChanged("Progress");
            }
        }

        private bool isStarted;
        public bool IsStarted
        {
            get { return isStarted; }
            set
            {
                isStarted = value;
                SetProperty(ref isStarted, value);
            }
        }

       private  bool statusIsVisible;
        public bool StatusIsVisible
        {
            get { return statusIsVisible; }
            set
            {
                statusIsVisible = value;
                SetProperty(ref statusIsVisible, value);
            }
        }

        private bool progressBarIsVisible;
        public bool ProgressBarIsVisible
        {
            get { return progressBarIsVisible; }
            set
            {
                progressBarIsVisible = value;
                SetProperty(ref progressBarIsVisible, value);
            }
        }
        protected void DoProgressBar()
        {
            
        }

        protected  void SearchDb(string searchValue)
        {

                        var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                        var obj = container.Resolve<T>();
                        if (searchValue == "")
                        {
                            repository.GetAll(obj, ViewState.ViewBackingClass, () =>
                            {
                                SetViewModelData();
                            });
                        }

                        else
                        {
                            repository.Find(obj, searchValue, ViewState.ViewBackingClass, () =>
                            {
                                SetViewModelData();
                            });
                        }
        }

        void VmData_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("VmData");
            ValidateCollection(e);
            
        }

        protected abstract void ValidateCollection(NotifyCollectionChangedEventArgs e);
    

        private void ReviewCollection(ReviewModeArgs obj)
        {
            ViewState.ViewMode.Push(FormMode.REVIEWMODE); 
            var dataList = repository.ReviewEditedItems();
            if (repository.DataStore == null)
            {
                repository.DataStore = VmData;
                VmData = dataList;
                IsReadOnly = true; 
            }
            else
            {
                VmData = repository.DataStore;
                repository.DataStore = null;
            }
            //InstanceFactory createor =new InstanceFactory();
            //var x=createor.GetInstance<T>(m_modelName);


            //ObservableCollection<T> myCollection = new ObservableCollection<int>(x);

            //VmData = oc;

        }

        //private void CommitCollection(CommitModeArgs obj)
        //{
        //    viewService.CurrentVmOperation = FormMode.COMMIT;
        //    //SetSqlStatement();
        //    repository.UpdateDb(output =>
        //    {
        //        IsReadOnly = true;
        //        if (viewService != null)
        //        {
        //            viewService.CurrentVmOperation = FormMode.UNCHANGED;
        //            viewService.ViewMode.Push(FormMode.UNCHANGED);
        //            viewService.HasNoRecords = true;
        //            viewService.HasPendingCommits = false;
        //        }
        //    });

        //}


        private void CommitCollection(CommitModeArgs obj)
        {
            ViewState.ViewMode.Push(FormMode.COMMIT);
            if (obj.ViewName == m_modelName)
            {
                IsReadOnly = true;
                //SetSqlStatement();
                repository.UpdateDb(output => 
                {
                    LoadData();
                    DefaultMode();
                });
            }
        }

        private void RefreshToCollection(RefreshModeArgs obj)
        {
            ViewState.ViewMode.Push(FormMode.REFRESHMODE); 
            repository.ClearCrudedItems();
            DefaultMode();
            ReLoadData();
        }

        protected virtual void SaveToCollection(SaveModeArgs obj)
        {
            ViewState.ViewMode.Push(FormMode.SAVED); 
            //repository.GetShippingMethods
            if (obj.ViewName == m_modelName)
            {
                IsReadOnly = true;
                var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                if(!DataStoreContainsDuplicates())
                {
                    
                        repository.SaveNoCommit(obj.FormState, _selectedItem);
              
                        //Do not send message to view if a delete
                        if (obj.FormState != FormMode.DELETEMODE)
                        {
                            
                            ViewState.CurrentVmOperation = FormMode.SAVED;
                            ViewState.HasPendingCommits = repository.HasPendingCommits();
                            var msg = new VmOnSave(ViewState.ViewMode.Peek());
                            eventAggregator.GetEvent<VmOnSaveEvent>().Publish(msg);
               
                        }
                }
                else
                {
                    SendMessageBox("Duplicate Error Warning", "Duplicates not allowed");
                   
                    IsReadOnly = false;
                }
            }
        }

        private void DeleteToCollection(DeleteModeArgs obj)
        {
            ViewState.ViewMode.Push(FormMode.DELETEMODE);
            if (obj.ViewName == m_modelName)
            {


                //On delete we need to save collection

                SaveToCollection(new SaveModeArgs { ViewName = obj.ViewName, FormState = FormMode.DELETEMODE });

                VmData.Remove(SelectedItem);

                bool isEmpty = !_vmData.Any();



                ViewState.CurrentVmOperation = FormMode.DELETEMODE;
                ViewState.HasPendingCommits = repository.HasPendingCommits();
                ViewState.HasNoRecords = true;

                var msg = new VmOnDelete();
                var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                eventAggregator.GetEvent<VmOnDeleteEvent>().Publish(msg);
            }
               
        }

        //protected void EditToCollection(EditModeArgs obj)
        //{
        // EditRow();

        //        //IsReadOnly = false;
              
        

        //        //ViewState.CurrentVmOperation = FormMode.EDITMODE;
        //        //ViewState.HasPendingCommits = repository.HasPendingCommits();
        //        //ViewState.HasNoRecords = true;

        //        //var msg = new VmOnEdit();
            
        //        //var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
        //        //eventAggregator.GetEvent<VmOnEditEvent>().Publish(msg);
            
        //}

        //virtual protected  void AddToCollection(AddModeArgs obj)
        //{
           

        //    ViewState.ViewMode .Push (FormMode.ADDMODE);
        //    if (obj.ViewName == ViewState.ViewBackingClass)
        //    {
                
        //        lock (_shippingMethodLock)
        //        {

        //            if (!repository.HasPendingCommits())
        //            {
        //                //park current collection into datastore
                       

        //            }
          
                    
        //        }

        //        IsReadOnly = false;

        //        ViewState.HasNoRecords = VmData==null ?false:VmData.Any();
        //        ViewState.HasPendingCommits = repository.HasPendingCommits();
        //        ViewState.CurrentVmOperation = FormMode.ADDMODE;


        //        var msg = new VmOnAdd();
               
        //        var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
        //        eventAggregator.GetEvent<VmOnAddEvent>().Publish(msg);

        //            //PageTitle page = (PageTitle)System.Enum.Parse(typeof(PageTitle), "AddUser");


        //            //eventAggregator.GetEvent<NavigationMessageEvent>().Publish(new NavigationMessage(page));  
                    
        //    }
        //}



        private T _selectedItem;
        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                {
                    var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

                

                        container.RegisterInstance(value, new ExternallyControlledLifetimeManager());

                        var item = container.Resolve<T>();
                    bool changesMade = repository.HasPendingCommits();
                        ViewState.HasPendingCommits = changesMade;
                        ViewState.CurrentVmOperation = FormMode.SELECTMODE;
                        //var msg = new VmOnSelect();
                       
                        //var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                        //eventAggregator.GetEvent<VmOnSelectEvent>().Publish(msg);

                        EventHandler handler = ItemSelectedEvent;
                        if (handler != null)
                        {
                            handler(value, null);
                        }




                    
                    if (ViewState.ViewMode.Peek() == FormMode.UNCHANGED)
                    {
                        IsReadOnly = true;
                    }
                    else
                    {
                        IsReadOnly = false;
                    }

                    if (_selectedItem != value)
                            SetProperty(ref _selectedItem, value);
                    
                }
            }
        }

        private void DefaultMode()
        {
            ////FormState = FormMode.UNCHANGED;
            ////var msg = new ViewService();
            ////msg.ViewMode = FormMode.UNCHANGED;
            ////msg.ViewName = m_modelName;
            ////msg.CurrentVmOperation = FormMode.UNCHANGED;
            //var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

            //var msg = new VmOnLoad();
            //eventAggregator.GetEvent<VmOnLoadEvent>().Publish(msg);
            IsReadOnly = true;

        }

        public virtual void CallRaisePropertyChangedForAllProperties()
        {
            // Refresh the page to bring show updated values.
            var query = from properties in GetType().GetProperties()
                        select properties;

            foreach (var prop in query)
            {
                OnPropertyChanged(prop.Name);
            }
        }

        private bool _IsActive;
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
               // SaveCommand.IsActive = value;
                IsActiveChanged(this, EventArgs.Empty);
            }
        }



        private bool isCancelled;
        public bool IsCancelled
        {
            get
            {
                return isCancelled;
            }

            set
            {
                if (isCancelled != value)
                    SetProperty(ref isCancelled, value);
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
                if (isReadOnly != value)
                {
                    SetProperty(ref isReadOnly, value);
                    IsEnabled = !isReadOnly;
                }
            }
        }

        private bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                if (isEnabled != value)
                    SetProperty(ref isEnabled, value);
            }
        }



        private bool canSelectItem;
        public bool CanSelectItem
        {
            get
            {
                return canSelectItem;
            }

            set
            {
                if (canSelectItem != value)
                    SetProperty(ref canSelectItem, value);
            }
        }

        private ObservableCollection<T> _vmData;
        public ObservableCollection<T> VmData
        {
            get
            {
                return _vmData;
            }

            set
            {
                if (_vmData != value)
                    SetProperty(ref _vmData, value);
                ViewState.HasNoRecords = !_vmData.Any();
            }
        }

       

        protected IList<T> GetRowForEditing(IEnumerable<T> current)
        {
            
            var data = current.FirstOrDefault();
            IList<T> list = current.ToList();
            VmData = new ObservableCollection<T>(list);
            SelectedItem = VmData.FirstOrDefault();
            //var notExcluded = repository.ViewModelData.Except(data);
            //VmData.Remove(data);

            return list;
        }

        //protected ObservableCollection<T> CreateNewCollection()
        //{
        //    ObservableCollection<T> lst = new ObservableCollection<T>();
           
          
        //    //lst.CollectionChanged  += VmData_CollectionChanged;
        //    return lst;

        //}


        protected bool HasDuplicate()
        {
            return DataStoreContainsDuplicates() | VmDataContainsDuplicates();
        }

       
        protected void SendMessageBox(string title,string message)
        {
            
                    var msg = new NotificationMessage();
                    msg.Title = title;
                    msg.Message =message;

                    var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                    eventAggregator.GetEvent<NotificationMessageEvent>().Publish(msg);
        }

        protected virtual void DoSearchDb(SearchModeArgs obj)
        {
            if (obj.SearchValue != null) SearchDb(obj.SearchValue);
            else SendMessageBox("XXX","reder");
        }

        public void BeginProcess(string searchValue)
        {
            StatusIsVisible = true;
            ProgressBarIsVisible = true ; 
                 Action StartLoop;
            StartLoop = () => DoLongRunningProcess(searchValue);

            Thread t;

            t = new Thread(StartLoop.Invoke);
            t.Start();
        }

        public void CancelProcess()
        {
            isCancelled = true;
            Thread.Sleep(1500);
            
            //EnableBeginButton();
        }

        protected void UpdateProgressBar(double value)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { this.Progress = value; }, null);
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { this.StatusMessage = (value * 100).ToString(); }, null);
        }

        protected void HideProgressBar()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (SendOrPostCallback)delegate { this.ProgressBarIsVisible =false; }, null);
        }
        protected abstract bool DataStoreContainsDuplicates();

        protected abstract bool VmDataContainsDuplicates();

        protected IViewService  ViewState { get; set; }
        public ICommand DoubleClickCommand { get; set; }


        public event EventHandler IsActiveChanged = delegate { };
        //protected abstract ObservableCollection<T> NewCollection();
        //protected abstract T CreateNewITem();
        ////protected FormMode CurrentViewMode { get; set; }
        //protected abstract void EditCurrentRow();

        protected abstract void LoadData();

        protected abstract void ReLoadData();

        protected abstract void ReFreshDataContext();
        protected abstract void DoLongRunningProcess(string searchValue);
        protected abstract void DoWork(string searchValue);

        protected abstract void SaveToRepository(VmOnSave obj);

    }
}
