using Boytrix.Logic.DataAccess.DbUpdate.UpdateServiceReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.DataTransfer.DbUpdate
{
    public class UnitOfWork
    {
        public class DbUpdater : Boytrix.Logic.DataAccess.DbUpdate.IDbUpdater 
        {
            public async void UpdateDb(string sqlStatements, Action<string> completed)
            {
                string errMsg = await DoWork(sqlStatements);
                completed(errMsg);
            }

            private async Task<string> DoWork(string sqlStatements)
            {

                var proxy = new UpdateServiceClient();

                Debug.WriteLine("UpdateServiceClient instantiated");


                System.Diagnostics.Debug.WriteLine("SaveChangesAsync Async called");
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
}
