//using AspDotNetStorefrontEncrypt;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

//namespace Boytrix.Logic.Model.Classes.UserData
//{

//    //public class UserSecurityPermission:User
//    //{
//    //   [XmlIgnore]
//    //    public IList<SecurityPermission> UserPermissions { get; set; }
//    //}
//    [DbTableName("Users_Account")]
//    [FieldRelationShip("Users_Account", "ID",Join.INNER,"Users_UsersGroup","UserId")]
//     public class UserBasicInfo
//    {

//         public int ID { get; set; }
//         public string Login { get; set; }
//         public string FullName { get; set; }
//         [DoNotIncludeField]
//        public Guid UserGUID { get; set; }
//         [DoNotIncludeField]
//        public string Password { get; set; }
//        public int SaltKey { get; set; }
//        public bool IsAdmin { get; set; }
//        public bool IsActive { get; set; }
//        [DoNotIncludeField]
//        public bool IsNew { get; set; }
       
//        IEnumerable<Users_UsersGroup> UsersGroup { get; set; }
//    }

//    public class User:UserBasicInfo
//    {

       
       
//        public DateTime SessionStart { get; set; }
//        public String SystemUserID { get; set; }
//        public String IP { get; set; }
//        public String MachineName { get; set; }
      
//         [XmlIgnore]
//        public IList<SecurityPermission> UserPermissions { get; set; }
  
//    }

//    public class Users_UsersGroup
//    {
//        public int UserId{get;set;}
//        public int GroupId{get;set;}
//    }

//    //public class SecurityPermission
//    //{
//    //    public int ID { get; set; }
//    //    public String Name { get; set; }
//    //    public String SecurityID { get; set; }
//    //    public String Desc { get; set; }
//    //    public bool IsGroupPermission { get; set; }
//    //}

//    public class SecurityPermissionArgs : EventArgs
//    {
//        public int ID { get; set; }
//        public String Name { get; set; }
//        public String SecurityID { get; set; }
//        public String Desc { get; set; }
//        public bool IsGroupPermission { get; set; }
//    }

//    public class Password
//    {
//        private String m_ClearPassword = String.Empty;
//        private int m_Salt = 0;
//        private String m_SaltedPassword = String.Empty;

//        public static readonly int ro_RandomPasswordLength = 8;
//        public static readonly int ro_RandomStrongPasswordLength = 8;

//        public Password(String ClearPassword, int Salt)
//        {
//            m_ClearPassword = ClearPassword;
//            m_Salt = Salt;
//            m_SaltedPassword = Encrypt.ComputeSaltedHash(m_Salt, m_ClearPassword);
//        }


//        public Password(string ClearPassword)
//        {
//            m_ClearPassword = ClearPassword;
//            m_Salt = Encrypt.CreateRandomSalt();
//            m_SaltedPassword = Encrypt.ComputeSaltedHash(m_Salt, m_ClearPassword);
//        }


//        public Password()
//        {
//            m_ClearPassword = Encrypt.CreateRandomStrongPassword(8);
//            m_Salt = Encrypt.CreateRandomSalt();
//            m_SaltedPassword = Encrypt.ComputeSaltedHash(m_Salt, m_ClearPassword);
//        }


//        public String ClearPassword
//        {
//            get { return m_ClearPassword; }
//        }

//        public String SaltedPassword
//        {
//            get { return m_SaltedPassword; }
//        }

//        public int Salt
//        {
//            get { return m_Salt; }
//        }
//    }

//    public class RandomStrongPassword : Password
//    {
//        public RandomStrongPassword()
//            : base(Encrypt.CreateRandomStrongPassword(ro_RandomStrongPasswordLength), Encrypt.CreateRandomSalt())
//        {
//        }
//    }

//}

