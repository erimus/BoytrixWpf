using DataAccess;

namespace Boytrix.Data.Services.WCF.Admin.AdminService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminService.svc or AdminService.svc.cs at the Solution Explorer and start debugging.
    public class AdminService : IAdminService
    {

        public string GetShippingMethodListFromService()
        {
            var adminDal = new AdminDal();
            string theXml = adminDal.GetShippingMethodFromDBXml();
            return theXml;
        }

    }
}
