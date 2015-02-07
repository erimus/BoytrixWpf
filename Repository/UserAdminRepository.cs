using System;
using Boytrix.Logic.DataTransfer.Model;

namespace Boytrix.Logic.DataTransfer.Repository
{
    public class UserAdminRepository : RepositoryBase<UserBasicInfo>
    {
        public UserAdminRepository(CrudHandler<UserBasicInfo> cud)
            : base(cud)
        {
        }

        public override void GetModelData(Action<object, EventHandler> completedAction)
        {
            throw new NotImplementedException();
        }


      

        //public void SaveUserGroups(FormMode state, UserBasicInfo selectedRow, List<UserGroup> sgc)
        //{
        //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

        //    //  Add lib namespace with empty prefix
        //    ns.Add("", "http://schemas.ali.com/lib/");

        //    string strXML = BoytrixSerializer.SerializeObject<UserGroup>(Encoding.Default, ns, true, sgc);


        //    String strSQL;

        //    strSQL = String.Format("EXEC [UpdateUserGroups] {0},{1}", 0, DB.SQuote(strXML));

        //    base.HandleSaveNoCommitSP(state, selectedRow, strSQL);
        //}

    }
}
