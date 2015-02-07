using System;
using System.Collections.Generic;
using Boytrix.Logic.DataTransfer.Model;

namespace Boytrix.Logic.DataTransfer.Repository
{
    public class OrderRepository : RepositoryBase<ShippingMethod>
    {


        public OrderRepository(CrudHandler<ShippingMethod> cud)
            : base(cud)
        {
        }

        public IEnumerable<ShippingMethod> ShippingMethodsList { get; set; }



        public override async void GetModelData(Action<object, EventHandler> completedAction)
        {
           
            //IEnumerable<ShippingMethod>"ShippingMethod j = await GetMaterializedObject();

            //ViewModelData = j;

            //if (null != completedAction)
            //    completedAction(this, null);
            //}



        }

        public  void GetShippingMethod(Action<bool> completed)
        {
            GetAll(new ShippingMethod(), "ShippingMethod", () =>
            {
                completed(true);
            });
        }

        //protected override async Task<IEnumerable<ShippingMethod>> GetMaterializedObject()
        //{
        //    IEnumerable<ShippingMethod> j = await GetXmlFromService();

        //    return j;
        //}


        //protected async override Task<string> GetXmlFromServiceAsync()
        //{
        //    var proxy = new Boytrix.Logic.DataTransfer.Materializer.AdminServiceReference.AdminServiceClient();

        //    Debug.WriteLine("AdminServiceClient instantiated");


        //    System.Diagnostics.Debug.WriteLine("Get shipping Method Async called");
        //    var Result = await proxy.GetShippingMethodListFromServiceAsync();
        //    return Result;
        //}


    }
}
