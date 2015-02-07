
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Boytrix.Logic.DataTransfer.Materializer.UpdateServiceReference;

namespace Boytrix.Logic.DataTransfer.Materializer
{
    public class DataGetter
    {
        private UpdateServiceClient proxy;
        public DataGetter()
        {
            proxy = new UpdateServiceClient();
        }
        public async Task<string> GetAll(string className, string sql)
        {
   
            Debug.WriteLine("UpdateServiceClient instantiated");

            string task = await proxy.GetWithSqlAsync(className,sql);

            return task;

        }


        public async Task<string> Find(string className,string sql)
        {

            Debug.WriteLine("UpdateServiceClient instantiated");

            string task = await proxy.GetWithSqlAsync(className,sql);
            return task;

        }

        public async Task<string> GetWtihSp(string sql)
        {

            Debug.WriteLine("UpdateServiceClient instantiated");

            string task = await proxy.GetWithSpAsync(sql,60);
            return task;
        }

        public async Task<string> UpdateDb(string sqlStatements, Action<string> completed)
        {
            Debug.WriteLine("UpdateServiceClient instantiated");

            Debug.WriteLine("SaveChangesAsync Async called");
            try
            {
                string msg = "";
                msg = await proxy.SaveChangesAsync(sqlStatements);
                return msg;
            }

            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
