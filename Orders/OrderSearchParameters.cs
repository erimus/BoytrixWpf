//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Boytrix.UI.WPF.BoytrixModules.Order
//{
//    class SearchField
//    {
//        public SearchField(string fieldName, string friendlyName)
//        {
//            FieldName = fieldName;
//            FriendlyName = friendlyName;
//        }

//        int Id { get; set; }
//        string FieldName { get; set; }
//        string FriendlyName { get; set; }
//    }

//    internal class SearchBy
//    {
//        public List<SearchField> GetSearchByParameters()
//        {
//            var searchByFields = new List<SearchField>
//            {
//                new SearchField("ByOrderId", "By Order Id"),
//                new SearchField("ByCustomerId", "By Customer Id"),
//                new SearchField("ByOrderDate", "By Order Date"),
//                new SearchField("ByCustomerEmaili", "By Customer Emaili"),
//                new SearchField("ByShippingPostCode", "By Shipping PostCode"),
//                new SearchField("ByBillingPostCode", "By Billing PostCode"),
//                new SearchField("BySku", "By Sku"),
//                new SearchField("ByProductName", "By Product Name"),
//                new SearchField("ByImportDate", "By Import Date"),
//                new SearchField("ByExportDate", "By Export Date"),
//                new SearchField("ByShippingMethod", "By Shipping Method")
//            };
//            return searchByFields;
//        }

//    }

//}
