//using Boytrix.Logic.DataAccess.DbUpdate.UpdateServiceReference;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Boytrix.Logic.DataTransfer.Materializer
//{
//    public class DataGetter
//    {
//        public async Task<string> GetAll(string className, string sql)
//        {

           

//            var proxy = new   Boytrix.Logic.DataAccess.DbUpdate.UpdateServiceReference.UpdateServiceClient();

//            Debug.WriteLine("UpdateServiceClient instantiated");

//            string task = await proxy.GetWithSqlAsync(className,sql);

//            return task;

//        }


//        public async Task<string> Find(string className,string sql)
//        {

//            var proxy = new Boytrix.Logic.DataAccess.DbUpdate.UpdateServiceReference.UpdateServiceClient();

//            Debug.WriteLine("UpdateServiceClient instantiated");

//            string task = await proxy.GetWithSqlAsync(className,sql);
//            return task;

//        }

//        public async Task<string> GetWtihSp(string sql)
//        {

//            var proxy = new Boytrix.Logic.DataAccess.DbUpdate.UpdateServiceReference.UpdateServiceClient();

//            Debug.WriteLine("UpdateServiceClient instantiated");

//            string task = await proxy.GetWithSpAsync(sql,60);
//            return task;
//        }
//    }
//}
