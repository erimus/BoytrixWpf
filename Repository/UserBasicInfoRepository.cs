
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Boytrix.Logic.Business.Common;
using Boytrix.Logic.DataTransfer.Model;
using Boytrix.Logic.DataTransfer.Materializer;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.DataTransfer.Repository
{
    public class UserBasicInfoRepository : RepositoryBase<UserBasicInfo>
    {
        public UserBasicInfoRepository( CrudHandler<UserBasicInfo> cud)
            : base(cud)
        {
            //var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            //UsersUserGroups=container.Resolve<Users_UsersGroup>();
           
        }


        public IList<UserGroup> UserGroups { get; set; }

        public void SaveUserSp(FormMode state, UserBasicInfo selectedRow)
        {
           
            String strSQL;
            //(@uid nvarchar(50),@FullNmae nvarchar(100),@pswd NVARCHAR(MAX),@UserGuid uniqueidentifier,@IsAdmin bit,@IsActive bit)

            strSQL = String.Format("EXEC [usp_CreateUser] {0},{1}, {2},{3}, {4},{5}",
                DB.SQuote(selectedRow.Login),
                DB.SQuote(selectedRow.FullName),
            DB.SQuote(selectedRow.Password),
            DB.SQuote(selectedRow.UserGUID.ToString()),
            selectedRow.IsAdmin,
            selectedRow.IsActive
            );

            HandleSaveNoCommitSP(state, selectedRow, strSQL);
        }

        public void SaveUserGroups(FormMode state, UserBasicInfo selectedRow, List<Users_UsersGroup> sgc)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            //  Add lib namespace with empty prefix
            ns.Add("", "http://schemas.ali.com/lib/");

            string strXML = BoytrixSerializer.SerializeObject(Encoding.Default, ns, true, sgc);


            String strSQL;

            strSQL = String.Format("EXEC [usp_User_InsertXml] {0},{1}", DB.SQuote(selectedRow.UserGUID.ToString()), DB.SQuote(strXML));

            HandleSaveNoCommitSP(state, selectedRow, strSQL);
        }
        public void SearchDbWithSp(string searchValue, string elementName, Action<bool> completed)
        {
           

            Dictionary<string, object> paramList = new Dictionary<string, object>
            { 
                { "id", DB.SQuote(searchValue) }
         
            };
            base.SearchDbWithSp("[dbo].[usp_User_GetUserXML]", elementName, paramList, o =>
            {
             
              
                MaterializeUserGroup(elementName);
                MaterializeGroups(elementName);

                completed(o);
            });
         
        }

        private void MaterializeGroups(string elementName)
        {

            string xml = GetXmlFile(elementName);
            var data = Deserializer.DeSerializeObject<UserGroup>("UserGroups", xml);
            if (data !=null)
            {
               var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
               container.RegisterInstance<IEnumerable<UserGroup>>(data);
            }

        }

        private void MaterializeUserGroup(string elementName)
        {
            string xml = GetXmlFile(elementName);
            if (xml != null)
            {
                var lst = new List<Users_UsersGroup>();

                var messagesElement = XElement.Parse(xml);

                IEnumerable<XElement> elems = messagesElement.Descendants("Users_UsersGroups").Elements();

                foreach (XElement s in elems)
                {


                    lst.Add(new Users_UsersGroup
                    {
                        UserID = Convert.ToInt32(s.Element("UserID").Value),
                        GroupID = Convert.ToInt32(s.Element("GroupID").Value)
                        //(current.Element("lat").Value);
                    });

                }
                var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
                container.RegisterInstance<IEnumerable<Users_UsersGroup>>(lst);
         
            }
        }

        public override void GetModelData(Action<object, EventHandler> completedAction)
        {
            throw new NotImplementedException();
        }


        public void GetUserGroupsWithSp(string usergroup, Action<object> action)
        {
            
        }
    }
}
