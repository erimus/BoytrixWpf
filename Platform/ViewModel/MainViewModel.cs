using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.State;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.UI.Common.Utilities;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Base;
using Boytrix.UI.WPF.Libraries.Platform.Controls;
using Boytrix.UI.WPF.Libraries.Platform.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Application = System.Windows.Application;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public class MainViewModel:BindableBase
    {
       
        private readonly IViewState _currentViewState;
        private int current;
        private IViewCycler _viewCycler;

       // public IList<PageDetails> ViewsOpened { get; set; }
       
        public IViewService FormArgs { get; set; }
        public DelegateCommand<string> NewCollection { get; set; }
        public DelegateCommand<string> OpenCollection { get; set; }
        public DelegateCommand<string> SaveCollection { get; set; }
        public DelegateCommand<string> EditCollection { get; set; }
        public DelegateCommand<string> DeleteCollection { get; set; }
        //public DelegateCommand<string> RefreshCollection { get; set; }
        public DelegateCommand<string> CommitCollection { get; set; }
        public DelegateCommand<string> ReviewCollection { get; set; }
        public DelegateCommand<string> ShowUserView { get; set; }
        public DelegateCommand<string> ShowGroupView{ get; set; }
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; private set; }

        public ICommand SearchCommand { get; private set; }
        
        public ICommand RefreshCollectionCommand { get; private set; }
        public DelegateCommand GoNextCommand { get; private set; }

       
        public DelegateCommand GoPreviousCommand { get; private set; }

        private IUnityContainer container;
        private IEventAggregator eventAggregator;
        private IRegionManager regionManager;

        private VmStateContext _vmStateContext;

        public MainViewModel(IUnityContainer container, IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            this.container = container;
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;

            ViewRecordCommand = new DelegateCommand<string>(ViewRecord, CanViewRecord);
            NewCollection = new DelegateCommand<string>(AddNew, CanAddNew);
            OpenCollection = new DelegateCommand<string>(View, CanView);
            SaveCollection = new DelegateCommand<string>(Save, CanSave);
            EditCollection = new DelegateCommand<string>(Edit, CanEdit);
            DeleteCollection = new DelegateCommand<string>(Delete, CanDelete);
            RefreshCollectionCommand = new DelegateCommand<string>(Refresh, CanRefresh);
            CommitCollection = new DelegateCommand<string>(Commit, CanCommit);
            ReviewCollection = new DelegateCommand<string>(Review, CanReview);

            GoPreviousCommand = new DelegateCommand(GoPrevious,CanGoPrevious);
            GoNextCommand = new DelegateCommand(GoNext, CanGoNext);

            RecordNavGoFirstCommand = new DelegateCommand<string>(RecordNavGoFirst, CanRecordNavGoFirst);
            RecordNavGoNextCommand = new DelegateCommand<string>(RecordNavGoNext, CanRecordNavGoNext);
            RecordNavGoPreviousCommand = new DelegateCommand<string>(RecordNavGoPrevious, CanRecordNavGoPrevious);
            RecordNavGoLastCommand = new DelegateCommand<string>(RecordNavGoLast, CanRecordNavGoLast);

            ShowUserView = new DelegateCommand<string>(ShowUsers, CanShowUsers);
            ShowGroupView = new DelegateCommand<string>(ShowGroups, CanShowGroups);
           

            ExitViewCommand = new DelegateCommand<string>(ExitView, CanExitView);


            

            eventAggregator.GetEvent<VmOnAddEvent>().Subscribe(OnAddEvent);
            eventAggregator.GetEvent<VmOnEditEvent>().Subscribe(OnEditEvent);
            eventAggregator.GetEvent<VmOnViewEvent>().Subscribe(OnViewEvent);
            //eventAggregator.GetEvent<VmOnDeleteEvent>().Subscribe(OnDeleteEvent);
            eventAggregator.GetEvent<VmOnReviewEvent>().Subscribe(OnReviewEvent);
            eventAggregator.GetEvent<VmOnSelectEvent>().Subscribe(OnSelectEvent);
            //eventAggregator.GetEvent<VmOnSaveEvent>().Subscribe(OnSaveEvent);
            eventAggregator.GetEvent<VmOnCommitEvent>().Subscribe(OnCommitEvent);
            eventAggregator.GetEvent<VmOnLoadEvent>().Subscribe(OnLoadEvent);
            eventAggregator.GetEvent<VmOnRefreshEvent>().Subscribe(OnRefreshEvent);

            eventAggregator.GetEvent<DoubleClickArgsEvent>().Subscribe(DoubleClickHandler);
            

            eventAggregator.GetEvent<ValidationArgsEvent>().Subscribe(OnValidation);

            eventAggregator.GetEvent<SelectedTabArgsEvent>().Subscribe(OnTabSelected);
            //eventAggregator.GetEvent<NotificationMessageEvent>().Subscribe(RaiseNotification);

           

            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            NotificationRequest = new InteractionRequest<INotification>();

            SearchCommand = new DelegateCommand<string>(DoSearch, CanDoSearch);

            ShowStatusbar();

      

            //ViewsOpened = lst;
          //  container.RegisterInstance<IEnumerable<PageDetails>>(lst, new ContainerControlledLifetimeManager());

           // this.container.RegisterType<IViewCycler, ViewCycler>(new ContainerControlledLifetimeManager());

            eventAggregator.GetEvent<NotificationMessageEvent>().Subscribe(OnNotificationReceived);


          

            StartViewMode();

           
            eventAggregator.GetEvent<OpenViewEvent>().Subscribe(OpenViewEventHandler);
          
        }

        private bool CanShowOpenOrderView(string arg)
        {
            return true;
        }

        private void ShowOpenOrderView(string obj)
        {
            FormArgs.ViewBackingClass = obj;
            ShowDisplayView(obj);

        }

     

        private void OpenViewEventHandler(OpenViewMessage obj)
        {
            _viewCycler.Clear();
        
            ShowView();
           // OrderTabIsSelected = true;
        }

       

        private void DoubleClickHandler(DoubleClickArgs obj)
        {
            ViewRecord(null);
            // var item = container.Resolve<T>();
            //SelectedItem = container.Resolve<T>();
        }

        public DelegateCommand<string> ViewRecordCommand { get; set; }

        private void ViewRecord(string obj)
        {

            _vmStateContext.BackingClass = FormArgs.ViewBackingClass;
            // _vmStateContext.Change(new AddState());
           
            var mode = FormArgs.ViewMode.Peek();
            if (mode == FormMode.ADDMODE | mode == FormMode.EDITMODE)
            {
                FormArgs.ViewMode.Pop();
            }
            if (mode == FormMode.UNCHANGED | mode == FormMode.VIEWMODE)
            {
                FormArgs.ViewMode.Push(FormMode.VIEWMODE);
                _vmStateContext.ViewMode();
                ShowView();
               
            }
           

            //FormArgs.ViewMode.Push(FormMode.WIP);
        }

        private bool CanViewRecord(string arg)
        {
            return FormArgs == null ? false : FormArgs.HasNoRecords==false ;
        }

        private void OnTabSelected(SelectedTabArgs obj)
        {
            FormArgs.ViewBackingClass = obj.BackingClass;
            UpdateButtonState();
        }
        private void StartViewMode()
        {
            _viewCycler = new ViewCycler(new List<PageDetails>());
            var vw = new ViewService
            {
                CurrentVmOperation = FormMode.UNCHANGED,
                HasNoRecords = true,
                HasPendingCommits = false,



            };
            vw.ViewMode.Push(FormMode.UNCHANGED);
            container.RegisterInstance<IViewService>(vw);
            FormArgs = vw;
            IVmState vmState = new StartState();
            _vmStateContext = new VmStateContext(vmState);
            _vmStateContext.StartMode();

            IViewState v = new HomeViewState();
          

            ButtonVisibilty = _vmStateContext.ButtonVisibilty;           
           //FormArgs = container.Resolve<IViewService>();
        }

      

        private void OnNotificationReceived(NotificationMessage obj)
        {
            RaiseNotification(obj);
        }
        private bool CanGoNext()
        {
            return _viewCycler.CanGoNext();
        }

        private void  GoNext()
        {
            _viewCycler.GoNext();
            regionManager.Regions[RegionNames.WorkspaceRegion].Activate(_viewCycler.CurrentPage.View);
            //_vmStateContext = _viewCycler.CurrentPage.VmStateContext;
            ButtonVisibilty = _viewCycler.CurrentPage.ButtonState;
            GoPreviousCommand.RaiseCanExecuteChanged();
            GoNextCommand.RaiseCanExecuteChanged();
            UpdateButtonState();
        }

        private bool CanGoPrevious()
        {
            return _viewCycler.CanGoPrevious();
        }
        private void GoPrevious()
        {
            _viewCycler.GoPrevious();
            regionManager.Regions[RegionNames.WorkspaceRegion].Activate(_viewCycler.CurrentPage.View);
            //_vmStateContext = _viewCycler.CurrentPage.VmStateContext;
            ButtonVisibilty = _viewCycler.CurrentPage.ButtonState;
            GoPreviousCommand.RaiseCanExecuteChanged();
            GoNextCommand.RaiseCanExecuteChanged();
            UpdateButtonState();
        }




        private void OnValidation(ValidationArgs obj)
        {
            var sb = new StringBuilder();
            int i = 0;
            while (i < obj.Validation.Count)
            {
                sb.Append(i+1 + ".");
                sb.Append(obj.Validation[i].ErrorText);
                sb.Append(Environment.NewLine);
                i++;
            }
            var msg = new NotificationMessage();
            msg.Message = sb.ToString();
            msg.Title = "Validation Error";
            RaiseNotification(msg);
          
        }

        private bool CanExitView(string arg)
        {
            var mode = FormArgs.ViewMode.Peek();
            if (mode == FormMode.WIP)
            {
                FormArgs.ViewMode.Pop();
            }
            var vws = regionManager.Regions[RegionNames.WorkspaceRegion].ActiveViews.FirstOrDefault();
            if (vws != null)
            {
                //var singleView = vws.ToString();
                //var index =
                //    ViewsOpened.IndexOf(ViewsOpened.Where(x => x.PageName == singleView).FirstOrDefault());
                //return ViewsOpened.Count-1 == index;
            }
            return true;
        }

        private void ExitView(string obj)
        {
            CloseView(obj);
        }

        private bool CanRecordNavGoLast(string arg)
        {
            return true;
        }

        private void RecordNavGoLast(string obj)
        {
            var msg = new RecordMoveLast();
            eventAggregator.GetEvent<RecordMoveLastEvent>().Publish(msg);
        }

        private bool CanRecordNavGoPrevious(string arg)
        {
            return true;
        }

        private void RecordNavGoPrevious(string obj)
        {
            var msg = new RecordMovePrevious();
            eventAggregator.GetEvent<RecordMovePreviousEvent>().Publish(msg);
        }

        private bool CanRecordNavGoNext(string arg)
        {
            return true;
        }

        private void RecordNavGoNext(string obj)
        {
            var msg = new RecordMoveNext();
            eventAggregator.GetEvent<RecordMoveNextEvent>().Publish(msg);
        }

        private bool CanRecordNavGoFirst(string arg)
        {
            return true;
        }

        private void RecordNavGoFirst(string obj)
        {
            var msg = new RecordMoveFirst();
            eventAggregator.GetEvent<RecordMoveFirstEvent>().Publish(msg);
        }

      
        private void OnAddEvent(VmOnAdd obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
        
            UpdateButtonState();
        }

        private void OnLoadEvent(VmOnLoad obj)
        {
            var vw = container.Resolve<IViewService>();
            FormArgs.CurrentVmOperation = obj.Vmode;
            HomeTabIsSelected = vw.CurrentVmOperation == FormMode.UNCHANGED | vw.ViewMode.Peek()  == FormMode.UNCHANGED | vw.HasNoRecords == false | vw.HasPendingCommits == false;
            UpdateButtonState();

        }
        private void OnEditEvent(VmOnEdit obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();

            var msg = new EditModeArgs();
            msg.ViewName = FormArgs.ViewBackingClass;
            eventAggregator.GetEvent<EditModeArgsEvent>().Publish(msg);
        }
     
        private void OnRefreshEvent(VmOnRefresh obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();
        }
   
        private void OnSelectEvent(VmOnSelect obj)
        {
           // _vmStateContext.SelectMode();
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();
        }
        private void OnViewEvent(VmOnView obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();
        }

        private void OnReviewEvent(VmOnReview obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();
        }

        private void OnCommitEvent(VmOnCommit obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();
        }

        private void OnCancelEvent(VmOnAdd obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();
        }
        private void OnDataLoadedEvent(VmOnAdd obj)
        {
            FormArgs.CurrentVmOperation = obj.Vmode;
            UpdateButtonState();
        }

        protected void DoSearch(string obj)
        {
            var msg = new SearchModeArgs();
            msg.SearchValue = obj;
            eventAggregator.GetEvent<SearchModeArgsEvent>().Publish(msg);
            UpdateButtonState();
        }

        private bool CanDoSearch(string arg)
        {
            return true;


            //return FormArgs == null ? false : FormArgs.CurrentVmOperation == FormMode.SELECTMODE || FormArgs.ViewMode.Peek()   ==FormMode.UNCHANGED ;
        }


        private void ShowStatusbar()
        {
            
       

            regionManager.RegisterViewWithRegion(RegionNames.StatusBarRegion,
                                                     () => container.Resolve<StatusBarControl>());
        }


        private MsgBoxResult RaiseConfirmation(string title, string confirmationMessage)
        {
            var j = MsgBoxResult.None;

            ConfirmationRequest.Raise(
                new Confirmation { Content = title, Title = confirmationMessage },
                c => { j = c.Confirmed ? MsgBoxResult.OK : MsgBoxResult.Cancel; });
            return j;
        }

        private void  ShowUsers(string obj)
        {
            ShowDisplayView(obj);
        }

        private void ShowDisplayView(string obj)
        {
            //FormArgs.TabSelectedIndex = (int)UserAdminTab.UserBasicInfo;
            _vmStateContext.BackingClass = obj;

            current = regionManager.Regions[RegionNames.WorkspaceRegion].Views.Count();
            var ix = _viewCycler.CurrentPage == null ? 1 : _viewCycler.CurrentPage.PageIndex + 1;
            if (ix ==1 && current==1)
            {
                //CloseView(obj);
                var singleView = regionManager.Regions[RegionNames.WorkspaceRegion].ActiveViews.FirstOrDefault();
                regionManager.Regions[RegionNames.WorkspaceRegion].Deactivate(singleView);

                regionManager.Regions[RegionNames.WorkspaceRegion].Remove(singleView);

                var msg = new CloseViewMessage();


                eventAggregator.GetEvent<CloseViewEvent>().Publish(msg);


                _viewCycler.Remove(_viewCycler.CurrentPage);
                FormArgs.ViewBackingClass = obj;
            }
                _vmStateContext.Change(new DisplayState());
            _vmStateContext.Display();
            ShowView();
            
         
        }

        private void ShowGroups(string obj)
        {
            FormArgs.TabSelectedIndex =(int) UserAdminTab.UserGroup;
            _vmStateContext.BackingClass = obj;

            _vmStateContext.Change(new EditState());
            _vmStateContext.EditMode();

            ShowView();
            var vw = container.Resolve<IViewService>();
            HomeTabIsSelected = vw.CurrentVmOperation == FormMode.UNCHANGED | vw.ViewMode.Peek() == FormMode.UNCHANGED;
        }

        private bool CanShowGroups(string arg)
        {
            return true;
        }
        private void ShowView()
        {
          
            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var formArgs = container.Resolve<IViewService>();
            var mode = formArgs.ViewMode.Peek();

            if (!formArgs.ViewExistsFlag)
            {
                var inx = regionManager.Regions[RegionNames.WorkspaceRegion].Views.Count()-1;
                //var pageDegtails = new PageDetails(formArgs.ViewName, page, pageType, mode, inx, _vmStateContext);
                var singleView = regionManager.Regions[RegionNames.WorkspaceRegion].ActiveViews.FirstOrDefault();
                var pageDegtails = new PageDetails(inx, singleView, _vmStateContext.ButtonVisibilty);
              
                _vmStateContext.CurrentPageDetail = pageDegtails;
                _viewCycler.Add(_vmStateContext.CurrentPageDetail);
            }

            var region = regionManager.Regions[RegionNames.RibbonRegion];

            //var tbr = ServiceLocator.Current.GetInstance<object>(formArgs.ToolbarName);
            //Type T = tbr.GetType();
            //foreach (var view in region.Views)
            //{
            //    if (view != null)
            //    {
            //       if (view.GetType() == T) 
            //        {
            //            region.Activate(view);
            //            Type type = this.GetType();

            //            PropertyInfo prop = type.GetProperty(formArgs.ToolbarName + "IsSelected");
            //            IsSearchEnabled = true;
            //            prop.SetValue(this, true, null);
            //            break;
            //        }
            //    }
            //}

            IsSearchEnabled = true;
           // regionManager.Regions[RegionNames.RibbonRegion].Activate(tbr);
            formArgs.ViewExistsFlag = false;
           // ButtonVisibilty = _vmStateContext.ButtonVisibilty;
               
            GoPreviousCommand.RaiseCanExecuteChanged();
            GoNextCommand.RaiseCanExecuteChanged();
            UpdateButtonState();
        }

        private void CloseView(string obj)
        {
            current = regionManager.Regions[RegionNames.WorkspaceRegion].Views.Count();
            var ix = _viewCycler.CurrentPage == null ? 1 : _viewCycler.CurrentPage.PageIndex + 1;
            if (ix < current)
            {
                return;
            }

            var singleView = regionManager.Regions[RegionNames.WorkspaceRegion].ActiveViews.FirstOrDefault();
            var mode = FormArgs.ViewMode.Peek();




            if (singleView != null)
            {


                




                    regionManager.Regions[RegionNames.WorkspaceRegion].Deactivate(singleView);

                    regionManager.Regions[RegionNames.WorkspaceRegion].Remove(singleView);

                    var msg = new CloseViewMessage();


                    eventAggregator.GetEvent<CloseViewEvent>().Publish(msg);

                    if (mode == FormMode.SAVED)
                    {
                        FormArgs.ViewMode.Pop();
                    }
                    if (mode == FormMode.VALIDATION)
                    {
                        FormArgs.ViewMode.Pop();
                    }
                    if (mode == FormMode.ADDMODE | mode == FormMode.EDITMODE)
                    {
                        FormArgs.ViewMode.Pop();
                    }


                    _viewCycler.Remove(_viewCycler.CurrentPage);

                if (_viewCycler.CurrentPage != null)
                {
                    regionManager.Regions[RegionNames.WorkspaceRegion].Activate(_viewCycler.CurrentPage.View);
                    ButtonVisibilty = _viewCycler.CurrentPage.ButtonState;

                    GoPreviousCommand.RaiseCanExecuteChanged();
                    GoNextCommand.RaiseCanExecuteChanged();
                }
                if (null == _viewCycler.CurrentPage)
                    {
                        if (mode == FormMode.UNCHANGED)
                        {
                            if (FormArgs.HasPendingCommits)
                            {
                                var m = new NotificationMessage();
                                m.Message = "Uncommitted transactions Please Review";
                                m.Title = "Uncommitted transactions";
                                RaiseNotification(m);
                                return;
                            }
                            //else
                            //   // FormArgs.ViewMode.Pop();
                        }
                        LastView();
                        StartViewMode();

                        return;
                    }
                
                //ButtonVisibilty = _viewCycler.CurrentPage.VmStateContext.ButtonVisibilty;

                    //eventAggregator.GetEvent<NavigationMessageEvent>()
                    //    .Publish(new NavigationMessage(_viewCycler.CurrentPage.PageTitle));
                }
            
            else
            {
                Application.Current.Shutdown();
                ;
            }


        }

        private bool CanShowUsers(string arg)
        {
            return true;
        }



        private void LastView()
        {
            FormArgs = null;
            _viewCycler = null;


        }

        private void Review(string obj)
        {

            var msg = new ReviewModeArgs(); 
            msg.ViewName = FormArgs.ViewBackingClass;
            eventAggregator.GetEvent<ReviewModeArgsEvent>().Publish(msg);
        }

        private bool CanReview(string arg)
        {
          
            return FormArgs == null ? false : FormArgs.HasPendingCommits;
        }

        private void Commit(string obj)
        {
            FormArgs.ViewMode.Push(FormMode.COMMIT);
            var msg = new CommitModeArgs { ViewName = FormArgs.ViewBackingClass };
            eventAggregator.GetEvent<CommitModeArgsEvent>().Publish(msg);
            CloseView(FormArgs.ViewBackingClass);
            
        }

      
        private bool CanCommit(string arg)
        {
          
            return FormArgs == null ? false :FormArgs.HasPendingCommits| FormArgs.IsDirty;
        }

        private bool CanSave(string arg)
        {
            return FormArgs != null && FormArgs.HasPendingCommits == false | FormArgs.IsDirty;
            //bool b = FormArgs == null || FormArgs.ViewMode == FormMode.EDITMODE | FormArgs.ViewMode == FormMode.ADDMODE | FormArgs.ViewMode == FormMode.DELETEMODE;

            //if a user can save he can equally choose to commit stratight away
            //var mode = FormArgs.ViewMode.Peek();
            //return FormArgs != null && FormArgs.HasPendingCommits | FormArgs.IsDirty;
           // return FormArgs != null && mode == FormMode.WIP | mode == FormMode.ADDMODE | mode == FormMode.EDITMODE | mode == FormMode.VALIDATION | FormArgs.HasNoRecords == false;
            //return FormArgs == null || (mode == FormMode.EDITMODE | mode == FormMode.ADDMODE | mode == FormMode.DELETEMODE) && (FormArgs.HasNoRecords == false);
           // return FormArgs == null ? false : FormArgs.HasNoRecords == true;
        }
        private void Save(string obj)
        {
            var val = new SaveModeArgs { ViewName = FormArgs.ViewBackingClass };
            eventAggregator.GetEvent<SaveModeArgsEvent>().Publish(val);

            var mode = FormArgs.ViewMode.Peek();
           
            
           
            if (mode == FormMode.VALIDATION)
            {
                FormArgs.ViewMode.Pop();

               // FormArgs.ViewMode.Push(FormMode.WIP);
            }
            UpdateButtonState();
        }

      
        private bool CanRefresh(string arg)
        {
            return true;
        }

        private void Refresh(string obj)
        {

            var result = RaiseConfirmation( "With this opeation all unsaved work will be lost. Continue?","Refresh");

            if (result == MsgBoxResult.OK)
            {
               // FormArgs.ViewMode = FormMode.UNCHANGED;

                FormArgs.ViewMode.Push(FormMode.REFRESHMODE);
                var msg = new RefreshModeArgs { ViewName = FormArgs.ViewBackingClass };
                eventAggregator.GetEvent<RefreshModeArgsEvent>().Publish(msg); 
            }
           
        }

   

        private void Delete(string obj)
        {
           
            var msg = new DeleteModeArgs { ViewName = FormArgs.ViewBackingClass };
            eventAggregator.GetEvent<DeleteModeArgsEvent>().Publish(msg);

            if (FormArgs.ViewMode.Peek() == FormMode.SAVED)
            {
                FormArgs.ViewMode.Pop();

                FormArgs.ViewMode.Push(FormMode.WIP);
            }
            DeleteCollection.RaiseCanExecuteChanged();
            SaveCollection.RaiseCanExecuteChanged();
            UpdateButtonState();

        }

        private bool CanDelete(string arg)
        {
            var mode = FormArgs.ViewMode.Peek();
            return FormArgs == null | FormArgs.HasNoRecords == false | FormArgs.IsDirty ;
            //return FormArgs == null || mode == FormMode.WIP | mode == FormMode.SAVED | FormArgs.HasNoRecords == false;
            //return FormArgs == null ? false : (mode != FormMode.EDITMODE || mode != FormMode.DELETEMODE || mode != FormMode.ADDMODE) && (FormArgs.HasNoRecords == false);           
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
            ViewRecordCommand.RaiseCanExecuteChanged();

           //IsSaveVisible = FormArgs == null ? false : FormArgs.HasNoRecords == false && FormArgs.ViewMode != FormMode.DELETEMODE;
           OnPropertyChanged("IsCommitVisible");
        }

        private bool CanEdit(string arg)
        {
            if (IsCurrentView)
                return FormArgs != null && FormArgs.HasNoRecords == false;
            else return false;

            //return FormArgs == null
            //    ? false
            //    : FormArgs.CurrentVmOperation != FormMode.EDITMODE || FormArgs.CurrentVmOperation != FormMode.DELETEMODE ||
            //      FormArgs.CurrentVmOperation != FormMode.SELECTMODE;
        }

        private void Edit(string obj)
        {
            var mode = FormArgs.ViewMode.Peek();

            if (mode == FormMode.ADDMODE)
            {
                //Incase you click edit from add
                FormArgs.ViewMode.Pop();
            }

            if (mode == FormMode.EDITMODE)
            {
                //Incase you click edit from add
                FormArgs.ViewMode.Pop();
            }

            if (mode == FormMode.UNCHANGED)
            {
                FormArgs.ViewMode.Push(FormMode.EDITMODE);
                _vmStateContext.Change(new EditState());

                _vmStateContext.EditMode();

                ShowView();

                //FormArgs.ViewMode.Push(FormMode.WIP);
                //var msg = new EditModeArgs();
                //msg.ViewName = FormArgs.ViewBackingClass;
                //eventAggregator.GetEvent<EditModeArgsEvent>().Publish(msg);
            }
            else
            {
                FormArgs.ViewMode.Push(FormMode.EDITMODE);
                ShowView();
            }

        }

       

        private bool CanView(string arg)
        {
            return FormArgs == null ? false : FormArgs.ViewMode.Peek() == FormMode.SELECTMODE | FormArgs.ViewMode.Peek() == FormMode.EDITMODE;
        }

        private void View(string obj)
        {
            FormArgs.ViewMode.Push(FormMode.VIEWMODE ) ;
            var msg = new ViewModeArgs {ViewName = FormArgs.ViewBackingClass};
            eventAggregator.GetEvent<ViewModeArgsEvent>().Publish(msg);

        }

        private bool CanAddNew(string arg)
        {

            //return FormArgs == null ? false : FormArgs.CurrentVmOperation != FormMode.EDITMODE | FormArgs.CurrentVmOperation != FormMode.DELETEMODE | FormArgs.ViewName !=null;
           if(IsCurrentView)
            return FormArgs != null && FormArgs.HasPendingCommits == false | FormArgs.IsDirty;
           else return false;

        }

        private void AddNew(string obj)
        {
           
            //ButtonVisibilty = v.ButtonVisibilty;
            //_viewCycler.Add(vcContext.CurrentPageDetail);
            //GoPreviousCommand.RaiseCanExecuteChanged();
            //GoNextCommand.RaiseCanExecuteChanged();

            var mode = FormArgs.ViewMode.Peek();

            if (mode == FormMode.EDITMODE)
            {
                //Incase you click edit from add
                FormArgs.ViewMode.Pop();
            }

            if (mode == FormMode.UNCHANGED)
            {
                FormArgs.ViewMode.Push(FormMode.ADDMODE);
                _vmStateContext.BackingClass = FormArgs.ViewBackingClass;
               // _vmStateContext.Change(new AddState());
                _vmStateContext.AddMode();

                ShowView();  
              
                FormArgs.ViewMode.Push(FormMode.WIP);
            }
            else
            {
                //still in Add mode
                //so auto save as a short cut from having to save
                //Save(obj);
                if (mode == FormMode.SAVED)
                {

                    FormArgs.ViewMode.Pop();           
                    FormArgs.ViewMode.Push(FormMode.WIP);
                    mode = FormArgs.ViewMode.Peek();
                }
                if (mode == FormMode.WIP)
                {
                 
                   
                }
                else
                {
                    var msg = new AddModeArgs {ViewName = FormArgs.ViewBackingClass};
                    eventAggregator.GetEvent<AddModeArgsEvent>().Publish(msg);
                    UpdateButtonState();
                }
            }

           
        }

        private bool _isSearchEnabled;
        public bool IsSearchEnabled
        {
            get
            {
                return _isSearchEnabled;
            }

            set
            {
                if (_isSearchEnabled != value)
                    SetProperty(ref _isSearchEnabled, value);
            }
        }

        //public bool OrderTabIsSelected { get; set; }

        private MsgBoxResult resultMessage;
        public MsgBoxResult InteractionResultMessage
        {
            get
            {
                return resultMessage;
            }
            set
            {
                resultMessage = value;
                OnPropertyChanged("InteractionResultMessage");
            }
        }

        private bool _orderTabIsSelected;
        public bool OrderRibbonTabIsSelected
        {
            get
            {
                return _orderTabIsSelected;
            }
            set
            {

                if (_orderTabIsSelected != value)
                    SetProperty(ref _orderTabIsSelected, value);
            }
        }


        private bool openOrderTabIsSelected;

        public bool OpenOrderTabIsSelected
        {
            get { return openOrderTabIsSelected; }
            set
            {

                if (openOrderTabIsSelected != value)
                    SetProperty(ref openOrderTabIsSelected, value);
            }
        }

        private bool homeTabIsSelected;
        public bool HomeTabIsSelected
        {
            get
            {
                return homeTabIsSelected;
            }
            set
            {

                if (homeTabIsSelected != value)
                    SetProperty(ref homeTabIsSelected, value);
            }
        }

        private bool reportTabIsSelected;
        public bool ReportTabIsSelected
        {
            get
            {
                return reportTabIsSelected;
            }
            set
            {

                if (reportTabIsSelected != value)
                    SetProperty(ref reportTabIsSelected, value);
            }
        }
        private bool userTabIsSelected;
        public bool UserTabIsSelected
        {
            get
            {
                return userTabIsSelected;
            }
            set
            {

                if (userTabIsSelected != value)
                    SetProperty(ref userTabIsSelected, value);
            }
        }
        

              private ButtonVisibiltyState _buttonVisibilty;
        public ButtonVisibiltyState ButtonVisibilty
        {
            get
            {
                return _buttonVisibilty;
            }
            set
            {
                if (_buttonVisibilty != value)
                {
                    
                    SetProperty(ref _buttonVisibilty, value);
                }
            }
        }

        private string _filterText;
       

        public string FilterText
        {
            get
            {
                return _filterText;
            }
            set
            {
                if (_filterText != value)
                {
                    
                    SetProperty(ref _filterText, value);
                }
            }
        }
        
        private void RaiseNotification(NotificationMessage obj)
        {


            NotificationRequest.Raise(
               new Notification { Content = obj.Message, Title = obj.Title },
               c => { });
        }


        public InteractionRequest<INotification> NotificationRequest { get; private set; }





        private bool IsCurrentView
        {
            get
            {
                var c = regionManager.Regions[RegionNames.WorkspaceRegion].Views.Count();
                var ix = _viewCycler.CurrentPage == null ? 1 : _viewCycler.CurrentPage.PageIndex + 1;
                return ix == c;
            }
        }

        public DelegateCommand<string> RecordNavGoFirstCommand { get; set; }

        public DelegateCommand<string> RecordNavGoNextCommand { get; set; }

        public DelegateCommand<string> RecordNavGoPreviousCommand { get; set; }


        public DelegateCommand<string> RecordNavGoLastCommand { get; set; }

        public DelegateCommand<string> ExitViewCommand { get; set; }
    }
}
