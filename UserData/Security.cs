//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Boytrix.Logic.Model.Classes.UserData
//{
//    public enum SecurityActions
//    {
//        Login,
//        Logout,
//        ChangePassword
//    }

//    public enum SecurityPermissionEnum
//    {
//        PURCHASE_ORDER,
//        PURCHASE_ORDER_SEND_PREADVICE_3PL,
//        GOODS_RECEIVED_3PL_WAREHOUSE,
//        CUSTOMER_RETURNS_3PL_WAREHOUSE,
//        STOCK_ADJUSTMENTS_3PL_WAREHOUSE,
//        INVOICE_MAPPING,
//        GOODRECEIVED_MAPPING,
//        IMPORT_PURCHASE_ORDER,
//        PRODUCTS,
//        PRODUCTS_SETTINGS,
//        SUPPLIERS,
//        WAREHOUSES,
//        PRODUCTS_IMPORT,
//        PRODUCTS_EXPORT,
//        PRODUCTSUPPLIER_UPDATE,
//        IMPORT_PROMO_PRODUCTS,
//        INVENTORY_STOCK_VIEW,
//        INVENTORY_STOCK_SYNC_3PL,
//        STOCK_ADJUSTMENTS,
//        ORDERS,
//        ORDERS_UPDATE_WAREHOUSE,
//        ORDERS_EXPORT_3PL_WAREHOUSE,
//        ORDERS_STATUS_UPDATE_3PL,
//        END_OF_DAY_PROCESS,
//        MANAGE_USERS,
//        MANAGE_GROUPS,
//        MANAGE_PERMISSIONS,
//        SYNC_PROD_SUP_INFO,
//        UPDATE_OFBIZ_INVENTORY,
//        REPORT_PRODUCT_PURCHASE_HISTORY,
//        REPORT_SUPPLIER_PURCHASE_ANALYSIS,
//        REPORT_STOCK_AJUSTMENT,
//        REPORT_CATALOG_LINKPRODUCTS,
//        REPORT_CATALOG_ALLPRODUCTS,
//        REPORT_WH_ORDERDESPATCH,
//        REPORT_WH_STOCKREMAINING

//    }

//    public class SecurityPermission
//    {
//        public int ID { get; set; }
//        public String Name { get; set; }
//        public String SecurityID { get; set; }
//        public String Description { get; set; }
//        public bool isGroup { get; set; }

//        SecurityPermission() { }

     

//    }

//    public class SecurityPermissionCollection : List<SecurityPermission>
//    {
//        public SecurityPermissionCollection() { }

    
//    }

   

//    public class SecurityGroupCollection : List<SecurityGroup>
//    {
//        public SecurityGroup FindGroup(int GroupID)
//        {

//            var m_data = from si in this where si.GroupID == GroupID select si;
//            if (m_data.Count() > 0)
//            {
//                return m_data.ToArray<SecurityGroup>()[0];
//            }
//            else
//                return null;
//        }

//        public SecurityGroup[] FindGroup(String GroupName)
//        {

//            var m_data = from si in this where si.GroupName == GroupName select si;
//            return m_data.ToArray<SecurityGroup>();
//        }

//        public SecurityGroup[] FindGroupIgnoreID(String GroupName, int GroupID)
//        {

//            var m_data = from si in this where si.GroupName == GroupName && si.GroupID != GroupID select si;
//            return m_data.ToArray<SecurityGroup>();

//        }


//        public SecurityGroupCollection()
//        { }

      
//    }

//    public class SecurityGroup
//    {
//        public int GroupID { get; set; }
//        public String GroupName { get; set; }
//        public String GroupDescription { get; set; }
//        public bool IsStatic { get; set; }
//        public bool IsNew { get; set; }

//        public SecurityGroup()
//        {
//        }
//    }

//    public class UserCollection : List<User>
//    {
//        public User FindUser(String UserID)
//        {

//            var m_data = from si in this where si.Login == UserID select si;
//            if (m_data.Count() > 0)
//            {
//                return m_data.ToArray<User>()[0];
//            }
//            else
//                return null;
//        }
//    }
//}
