using System;
using System.Xml.Serialization;
using Boytrix.Logic.Business.Common;

namespace Boytrix.Logic.DataTransfer.Model
{

    [DbTableName("Users_Groups")]
    public class UserGroup
    {
          [XmlIgnore]
         [DoNotIncludeField]
        public bool IsSelected{get;set;}
         [DoNotIncludeField]
        public int Id{get;set;}
        public string Name { get; set; }
        public string Description{get;set;}
       
    }

    //[DbTableName("Users_UsersGroups")]
    public class Users_UsersGroup
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }
         [XmlIgnore]
        public Guid UserGUID { get; set; }
    }
}
//id, name, description, created, updated, isStatic