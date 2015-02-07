    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

namespace DataAccess
{
    public class AdminDal
    {

        public string GetShippingMethodFromDBXml()
        {

            var connString = ConfigurationManager.ConnectionStrings["BoytrixWPFConn"];

            using (var conn = new SqlConnection(connString.ConnectionString))
            {
                string file;
                try
                {
                    var cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "usp_Admin_GetShippingMethodXML"
                    };
                    conn.Open();
                    var rdr = cmd.ExecuteXmlReader();

                    rdr.MoveToContent();
                    file = rdr.ReadOuterXml();

                    rdr.Close();
                    conn.Close();
                }
                    catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }

                return file;
            }
        }
    }
}
