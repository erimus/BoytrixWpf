using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Repository;
using Boytrix.UI.Common.Utilities.Behaviours;
using Boytrix.UI.Common.Utilities.EventMessages;
using Boytrix.UI.WPF.Libraries.Base;
using Boytrix.UI.WPF.Libraries.Base.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public class UserAdminViewModel : VmBase<UserBasicInfo>, IPageViewModel
    {

        public ICommand UserGroupSelectedItemCommand { get; set; }
      
        public  ICommand SelectedItemsCommand { get; set; }
        private UserBasicInfoRepository repository;
        private IUnityContainer container;
        private IViewService ViewService;
        public UserAdminViewModel(
            UserBasicInfoRepository repository, IViewService viewService)
            : base(repository)
        {
             container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            ViewService = viewService;
            this.repository = repository;
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<FileDialogArgsEvent>().Subscribe(DoOpenFileCallback);
         
            DoWork("-1");
            UploadImage = new DelegateCommand(DoUploadImage, CanUploadImage);
            SelectedItemsCommand = new DelegateCommand(DoSelectedItemsCommand, CanSelectedItemsCommand);

            UserGroupSelectedItemCommand = new DelegateCommand(DoUserGroupSelectedItemsCommand, CanUserGroupSelectedItemCommand);
         

            

            TabSelectedIndex = ViewService.TabSelectedIndex;
        }

        private bool CanUserGroupSelectedItemCommand()
        {
            return true;
        }

        private void DoUserGroupSelectedItemsCommand()
        {
            throw new NotImplementedException();
        }

        protected override void SaveToRepository(VmOnSave obj)
        {
            repository.SaveUserSp(obj.CurrentMode, obj.GetRow<UserBasicInfo>());
        }

        private bool CanSelectedItemsCommand()
        {
            throw new NotImplementedException();
        }

        private void DoSelectedItemsCommand()
        {
            throw new NotImplementedException();
        }

        private void DoUploadImage()
        {
            throw new NotImplementedException();
        }

        private bool CanUploadImage()
        {
            return DisplayedImagePath != null;
        }

        public ICommand UploadImage { get; set; }

        private void DoOpenFileCallback(FileDialogArgs msg)
        {
            if (msg.Identifier != "1234") return;
            // Store result in SelectedFiles
            DisplayedImagePath = msg.FullFileName;
        }


        //protected override ObservableCollection<UserBasicInfo> NewCollection()
        //{
        //    return new ObservableCollection<UserBasicInfo>();
        //}

        //protected override void AddToCollection(AddModeArgs obj)
        //{


        //    AddNewRow();
        //    var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
      
                

        //   var j= container.Resolve<Users_UsersGroup>();
           
        //    ObservableCollection<Users_UsersGroup> lst = new ObservableCollection<Users_UsersGroup>();
        //    lst.Add(j);

        //    container.RegisterInstance<IEnumerable<Users_UsersGroup>>(lst, new ExternallyControlledLifetimeManager());

        //    base.AddToCollection(obj); 
            
        //}
        protected override void DoSearchDb(SearchModeArgs searchMode)
        {

            DoWork(searchMode.SearchValue);
      
        }

        protected override void DoLongRunningProcess(string searchValue)
        {


           
        }
        //private bool CanDoDoubleClickEdit(object arg)
        //{
        //    return VmData.Any();
        //}

            public override  void DoDoubleClickEdit(object obj)
            {
                SelectedItem.GroupMemberships = (ICollection<Users_UsersGroup>)UserGroupMemberships.Where(x => x.UserID == SelectedItem.id).ToList();
              base.DoDoubleClickEdit(obj);
            }


        protected override void DoWork(string searchValue)
        {
            repository.SearchDbWithSp(searchValue, "UserBasicInfo", o =>
            {
                var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                var rows = container.Resolve<IEnumerable<UserBasicInfo>>("UserBasicInfo");

                VmData = new ObservableCollection<UserBasicInfo>(rows);

                var mgrps = container.Resolve<IEnumerable<UserGroup>>().ToList();
                UserGroups = new ObservableCollection<UserGroup>(mgrps);

                var memberships= container.Resolve<IEnumerable<Users_UsersGroup>>().ToList();
                UserGroupMemberships = memberships;
                IsReadOnly = true;
                EventHandler handler = null;
                ;

                handler = (s, e) =>
                {
                    //var item = (UserBasicInfo) s;
                    //if (item.GroupMemberships != null)
                    //    item.GroupMemberships = (ICollection<Users_UsersGroup>) UserGroupMemberships.Where(x => x.UserID == item.id);
                };
                ItemSelectedEvent -= handler;
                ItemSelectedEvent += handler;
            });
        }
        //protected override UserBasicInfo CreateNewITem()
        //{
         
        //    var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
        //    var item = container.Resolve<UserBasicInfo>();
        //    return item;
        //}

        protected override void SaveToCollection(SaveModeArgs obj)
        {
           
        }

        protected override void OnSaveEventHandler(VmOnSave obj)
        {
            var row = obj.GetRow<UserGroup>();
            if (row != null)
            {
                UserGroups.Add((UserGroup)row);
            }
            else
            {
                base.OnSaveEventHandler(obj);
            }

        }
        private int _selectedIndex;
        public int TabSelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                UserAdminTab myTab = (UserAdminTab)value;

                ViewService.ViewBackingClass = myTab.ToString();
                SetProperty(ref _selectedIndex, value);
                var msg = new SelectedTabArgs();
                msg.BackingClass = myTab.ToString();
               var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
               eventAggregator.GetEvent<SelectedTabArgsEvent>().Publish(msg);
                if (myTab == UserAdminTab.UserGroup && UserGroups==null)
                {
                    //repository.GetUserGroupsWithSp("UserGroup", (o) =>
                    //{
                    //    UserGroups = new ObservableCollection<UserGroup>(repository.UserGroups);
                    //});
                }
                if (myTab == UserAdminTab.UserGroup)
                {
                    ViewService.HasNoRecords = !UserGroups.Any();
                }
                else
                {
                    if (VmData != null) ViewService.HasNoRecords = !VmData.Any();
                }
            }
        }

        private UserGroup _selectedItem;
        public UserGroup UserGroupSelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                {

                    if (_selectedItem != value)
                        SetProperty(ref _selectedItem, value);
                    
                    container.RegisterInstance<UserGroup>(_selectedItem);
                    var msg = new VmOnSelect();

                    var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
                    eventAggregator.GetEvent<VmOnSelectEvent>().Publish(msg);
                  
                }
            }
        }
        private void SaveUserGroups(SecurityGroupCollection sgc)
        {
            throw new NotImplementedException();
        }
        
        //protected override void EditCurrentRow()
        //{
        //    var data = CreateNewCollection();
           
        //    data.Add(SelectedItem);


        //    var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
        //    var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
        //    container.RegisterInstance<IEnumerable<UserBasicInfo>>(data, new ExternallyControlledLifetimeManager());

           
        //    foreach (var view in regionManager.Regions[RegionNames.WorkspaceRegion].Views)
        //    {
        //        if (view != null)
        //        {
        //           // container.RegisterInstance<System.Windows.FrameworkElement>(view, new ExternallyControlledLifetimeManager());
        //            regionManager.Regions[RegionNames.WorkspaceRegion].Remove(view);
        //        }
        //    }

        //    regionManager.RegisterViewWithRegion(RegionNames.WorkspaceRegion,
        //                                            () => container.Resolve<AddUser>());
        //    var obj = new EditModeArgs();
        //    EditToCollection(obj);
        //}

        protected override void LoadData()
        {
            //repository.GetModelData((o, e) =>
          


            repository.GetModelData((o, e) =>
            {
                SetViewModelData();
                CreateSecurityPermissionEnumList();

            });
        }

        private void CreateSecurityPermissionEnumList()
        {
            SecurityPermissionEnumList=Enum.GetValues(typeof(SecurityPermissionEnum)).Cast<SecurityPermissionEnum>().ToList();
        }

        protected override void ReFreshDataContext()
        {
            LoadData();
        }

       

        protected override void ValidateCollection(NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override bool DataStoreContainsDuplicates()
        {
            return repository.DataStore == null ? false : repository.DataStore.Where(c => c.Login == SelectedItem.Login).Any();
        }

        protected override bool VmDataContainsDuplicates()
        {
            throw new NotImplementedException();
        }

        private string displayedImagePath;
        public string DisplayedImagePath
        {
            get
            {
                return displayedImagePath;
            }

            set
            {

                if (displayedImagePath != value)
                    SetProperty(ref displayedImagePath, value);
            }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {

                if (isSelected != value)
                    SetProperty(ref isSelected, value);
            }
        }

        private IEnumerable<SecurityPermissionEnum> securityPermissionEnumList;
        public IEnumerable<SecurityPermissionEnum> SecurityPermissionEnumList
        {
            get
            {
                return securityPermissionEnumList;
            }

            set
            {

                if (securityPermissionEnumList != value)
                    SetProperty(ref securityPermissionEnumList, value);
            }
        }

        private ObservableCollection<UserGroup> userGroups;
        public ObservableCollection<UserGroup> UserGroups
        {
            get
            {
                return userGroups;
            }

            set
            {

                if (userGroups != value)
                    SetProperty(ref userGroups, value);
            }
        }



        protected override void ReLoadData()
        {
            throw new NotImplementedException();
        }



        public ICollection<Users_UsersGroup> UserGroupMemberships { get; set; }
    }
}
