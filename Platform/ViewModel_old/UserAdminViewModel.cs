using Boytrix.Logic.DataAccess.Repository;
using Boytrix.Logic.Model.Classes.UserData;
using Boytrix.UI.WPF.Libraries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.UI.WPF.Libraries.Platform.ViewModel
{
    public class UserAdminViewModel : VmBase<UserBasicInfo>
    {
        public UserAdminViewModel(
            UserBasicInfoRepository repository)
            : base(repository,"UserBasicInfo")
        {
        }
        
        protected override System.Collections.ObjectModel.ObservableCollection<UserBasicInfo> NewCollection()
        {
            return new System.Collections.ObjectModel.ObservableCollection<UserBasicInfo>();
        }

        protected override UserBasicInfo CreateNewITem()
        {
            return new UserBasicInfo();
        }

        protected override void EditCurrentRow()
        {
            throw new NotImplementedException();
        }

        protected override void LoadData()
        {
            throw new NotImplementedException();
        }

        protected override void ReLoadData()
        {
            throw new NotImplementedException();
        }
    }
}
