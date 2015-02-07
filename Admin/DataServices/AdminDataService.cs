//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Boytrix.Logic.DataTransfer.Repository;
//using System.Collections.ObjectModel;
//using Boytrix.Logic.Model.Classes.AdminData;
//using Boytrix.Logic.Business.Common;

//namespace Boytrix.UI.WPF.BoytrixModules.Admin.DataServices
//{
//    public class AdminDataService : IAdminDataService
//    {
//        AdminRepository repository;
//        public AdminDataService(IAdminRepository repository)
//        {
//            this.repository = (AdminRepository)repository;
//           // GetShippingMethods();
//        }




//        public Task<IList<ShippingMethod>> GetShippingMethods()
//        {
//            var myList = repository.GetShippingMethods();
//            return myList;


//            //ObservableCollection<ShippingMethod> observable =
//            //new ObservableCollection<ShippingMethod>(myList.AsEnumerable<ShippingMethod>());
//            //return (ObservableCollection<ShippingMethod>)observable;
//           // ObservableCollection<ShippingMethod> observable =
//           //return new ShippingMethods(repository.GetAll().AsEnumerable<ShippingMethod>());
//        }
//    }
//}
