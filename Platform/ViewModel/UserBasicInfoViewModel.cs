//using System;
//using System.Collections.ObjectModel;
//using System.Collections.Specialized;
//using Boytrix.Logic.DataTransfer.Model;
//using Boytrix.Logic.DataTransfer.Repository;
//using Boytrix.UI.WPF.Libraries.Base;

//namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
//{
//    public class UserBasicInfoViewModel : VmBase<UserBasicInfo>
//    {
//        public UserBasicInfoViewModel(UserBasicInfoRepository repository)
//            : base(repository)
//        {

//        }
//        protected override void ValidateCollection(NotifyCollectionChangedEventArgs e)
//        {
//            throw new NotImplementedException();
//        }

//        protected override bool DataStoreContainsDuplicates()
//        {
//            throw new NotImplementedException();
//        }

//        protected override bool VmDataContainsDuplicates()
//        {
//            throw new NotImplementedException();
//        }

//        protected override ObservableCollection<UserBasicInfo> NewCollection()
//        {
//            throw new NotImplementedException();
//        }

//        protected override UserBasicInfo CreateNewITem()
//        {
//            throw new NotImplementedException();
//        }

//        protected override void EditCurrentRow()
//        {
//            throw new NotImplementedException();
//        }

//        protected override void LoadData()
//        {
//            //repository.GetModelData((o, e) =>
//            //{
//            //    SetViewModelData();
//            //    CreateSecurityPermissionEnumList();
//            //    IEnumerable<UserGroup> group = BoytrixSerializer.DeserializeParams<UserGroup>(repository.TaskResult);
//            //    UserGroups = group;
//            //});
//        }

//        protected override void ReFreshDataContext()
//        {
//            throw new NotImplementedException();
//        }

//        protected override void DoLongRunningProcess(string searchValue)
//        {
//            throw new NotImplementedException();
//        }

//        protected override void DoWork(string searchValue)
//        {
//            throw new NotImplementedException();
//        }

//        protected override void ReLoadData()
//        {
//            throw new NotImplementedException();
//        }

//    }
//}
