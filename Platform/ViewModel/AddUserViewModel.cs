using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.Business.Common.ViewState;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Repository;
using Boytrix.UI.Common.Utilities.Behaviours;
using Boytrix.UI.Common.Utilities.EventMessages;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using MvvmValidation;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public class AddUserViewModel : DetailViewModelBase<UserBasicInfo>
    {
     
       
        public AddUserViewModel(IEventAggregator eventAggregator, IUnityContainer container,  IViewService viewService)
            : base(eventAggregator, container,  viewService)
        {

            
           
         
            eventAggregator.GetEvent<FileDialogArgsEvent>().Subscribe(DoOpenFileCallback);

            UploadImage = new DelegateCommand(DoUploadImage, CanUploadImage);


            if (container != null)
            {
                var mgrps = container.Resolve<IEnumerable<UserGroup>>();
                if (mgrps != null)
                {
                    UserGroups = new ObservableCollection<UserGroup>(mgrps);
                }

                UserGroupMemberships = (IList<Users_UsersGroup>)container.Resolve<IEnumerable<Users_UsersGroup>>();

                if (ViewService.ViewMode.Peek() == FormMode.VIEWMODE)
                {
                    SelectedItem = container.Resolve<UserBasicInfo>();
                }
            }

           ;

            IsStandard = true;

            ConfigureValidationRules();
        }


        //public bool KeepAlive
        //{
        //    get { return false; }
        //}

        //protected override void AddToCollection(AddModeArgs obj)
        //{
           
        //    //base.AddToCollection(obj);
        //}

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

        private bool allSelected;
        public bool AllSelected
        {
            get
            {
                return allSelected;
            }

            set
            {

                if (allSelected != value)
                    SetProperty(ref allSelected, value);
            }
        }

        private bool _isStandard;
          public bool IsStandard
        {
            get
            {
                return _isStandard;
            }

            set
            {

                if (_isStandard != value)
                    SetProperty(ref _isStandard, value);
            }
        }
        
        
        //protected override void ValidateCollection(NotifyCollectionChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        protected override bool DataStoreContainsDuplicates(SaveModeArgs obj)
        {
            return VmData.Any(x => x.Login == obj.GetRow<UserBasicInfo>().Login);
            //return repository.DataStore == null ? false : repository.DataStore.Where(c => c.FullName == SelectedItem.FullName).Any();
        }

      
        protected override bool VmDataContainsDuplicates()
        {
            throw new NotImplementedException();
        }



        protected override void PreAddToCollection()
        {
            var grp = UserGroups;
            UserGroups = null;
            ClearAll();
            OnPropertyChanged("UserGroups");
            UserGroups = grp;
        }

        protected override void PostAddToCollection()
        {
            if (UserGroups != null)
            {

                foreach (var lvi in UserGroups.Where(x => x.IsSelected))
                {
                    lvi.IsSelected = false;
                }
                OnPropertyChanged("UserGroups");
            }

            var grp = UserGroups;
            ClearAll();
            SelectedItem.GroupMemberships=new List<Users_UsersGroup>();
         

        }

        protected override void PreDeleteFromCollection()
        {
            
        }

        protected override void PostDeleteFromCollection()
        {
            
        }

        protected override void DeleteItemFromCollection()
        {
            var itemToRemove = VmData.Single(x => x.FullName == SelectedItem.FullName && x.Login == SelectedItem.Login);
            VmData.Remove(itemToRemove);
        }

        protected override void PreEditCollection()
        {
            throw new NotImplementedException();
        }

        protected override void PostEditCollection()
        {
            throw new NotImplementedException();
        }

        private void ClearAll()
        {
            if (UserGroupMemberships != null) UserGroupMemberships.Clear();
            if (UserGroups != null) UserGroups.ToList().ForEach(x =>
            {
                x.IsSelected = false;
            });
            
        }

        protected override void SelectRelatedRecords()
        {
                if (SelectedItem != null && SelectedItem.GroupMemberships != null)
                {
                    var grp = UserGroups;
                    ClearAll();
                    SelectedItem.GroupMemberships.AsEnumerable().ForEach(x =>
                    {
                        var item = grp.FirstOrDefault(y => y.Id == x.GroupID);
                        if (item != null)
                            item.IsSelected = true;
                    });
                    UserGroups = null;
                    UserGroups = grp;
                    OnPropertyChanged("UserGroups");
                }
            
        }

        private void CreateSecurityPermissionEnumList()
        {
            SecurityPermissionEnumList = Enum.GetValues(typeof(SecurityPermissionEnum)).Cast<SecurityPermissionEnum>().ToList();
        }

        //protected override void ReFreshDataContext()
        //{
        //    LoadData();
        //}

        //protected override void DoLongRunningProcess(string searchValue)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override void DoWork(string searchValue)
        //{
        //    throw new NotImplementedException();
        //}

        protected override void SaveOtherObjectsPostVmData(SaveModeArgs obj)
        {
            var lst = SelectedItem.GroupMemberships.ToList();
            //repository.SaveUserGroups(obj.FormState, obj.GetRow<UserBasicInfo>(), lst);
            //var sgc = UserGroups.Where(x => x.IsSelected).Select(lvi => new UserGroup
            //{

            //    Description = lvi.Description,
            //    Name = lvi.Name,
            //    Id = lvi.Id,
            //    IsSelected = lvi.IsSelected

            //}).ToList();

            //repository.SaveUserGroups(obj.FormState, SelectedItem, sgc);
            ////Do not send message to view if a delete
            //if (obj.FormState != FormMode.DELETEMODE)
            //{

            //}
        }

        protected override void SaveOtherObjectsPriorToVmData(SaveModeArgs obj)
        {
            var pwd = new Password(SelectedItem.Login.ToLower());
            //SelectedItem.Password = pwd.SaltedPassword;
            //SelectedItem.SaltKey = pwd.Salt;
            SelectedItem.UserGUID = Guid.NewGuid();
            SelectedItem.IsNew = true;


    



            var usgc = UserGroups.Where(x => x.IsSelected).Select(lvi => new Users_UsersGroup
            {
                GroupID = lvi.Id,
                UserGUID = SelectedItem.UserGUID,
                UserID = SelectedItem.id
            }).ToList();

            usgc.ForEach(x =>
            {
                UserGroupMemberships.Add(x);
            });

            //Add memberships to user object

            SelectedItem.GroupMemberships = usgc;

     
         
        }

     

        private void SaveUserGroups(SecurityGroupCollection sgc)
        {
            
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


        private IEnumerable<SecurityGroup> SecurityGroups;

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

        private IList<Users_UsersGroup> userGroupMemberships;
        public IList<Users_UsersGroup> UserGroupMemberships
        {
            get
            {
                return userGroupMemberships;
            }

            set
            {

                if (userGroupMemberships != value)
                    SetProperty(ref userGroupMemberships, value);
            }
        }

        // get { return Get(() => Aid); }
        //    set { Set(() => Aid, value); }

        protected override void ConfigureValidationRules()
        {
            //Validator.AddRule(() => FirstName,() => RuleResult.Assert(!string.IsNullOrEmpty(FirstName), "First Name is required"));
            Validator.AddRule(() => SelectedItem.Login, () => RuleResult.Assert(!string.IsNullOrEmpty(SelectedItem.Login), "Login is required"));
                //SelectedItem.FullName.Length >3, () => RuleResult.Assert(!string.IsNullOrEmpty(SelectedItem.FullName)), "First Name is required"));
                // SelectedItem.FullName.Length < 50, () => RuleResult.Assert(!string.IsNullOrEmpty(FirstName), "First Name is required"));
                //SelectedItem.Login.Length>3, () => RuleResult.Assert(!string.IsNullOrEmpty(FirstName), "First Name is required"));
                //SelectedItem.Login.Length < 50 , () =>RuleResult.Assert(!string.IsNullOrEmpty(FirstName), "First Name is required"));
                //SelectedItem.Password.Length   >5, () =>RuleResult.Assert(!string.IsNullOrEmpty(FirstName), "First Name is required"));

        //    Validator.AddRule(() => UserGroups, () => UserGroups.Any(x => x.IsSelected), "Must belong to Group");
        }

        private bool isdisposed;
        public void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }



    }
}


