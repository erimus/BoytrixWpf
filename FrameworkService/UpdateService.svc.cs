using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FrameworkService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UpdateService : IUpdateService
    {
        public string SaveChanges(string sqlStatements)
        {
            var connString = ConfigurationManager.ConnectionStrings["BoytrixWPFConn"];
            StringBuilder errorMessages = new StringBuilder();


            using (var conn = new SqlConnection(connString.ConnectionString))
            {

                try
                {

                    var cmd = new SqlCommand
                    {

                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "[dbo].[usp_Unitofwork]"
                    };



                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@sql";
                    param.Value = sqlStatements;
                    cmd.Parameters.Add(param);


                    //Add the output parameter to the command object
                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@ReturnVal";
                    outPutParameter.SqlDbType = SqlDbType.Int;
                    outPutParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);

                    // get data stream
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var result = outPutParameter.Value;
                    conn.Close();
                    return result.ToString();
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    return errorMessages.ToString();
                }

                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public string GetWithSql(string className, string sqlStatements)
        {
            var connString = ConfigurationManager.ConnectionStrings["BoytrixWPFConn"];
            StringBuilder errorMessages = new StringBuilder();


            using (var conn = new SqlConnection(connString.ConnectionString))
            {
                string file;
                try
                {

                    var cmd = new SqlCommand
                    {

                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "[dbo].[usp_Unitofwork_get]"
                    };



                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@sql";
                    param.Value = sqlStatements;
                    cmd.Parameters.Add(param);

                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@ClassName";
                    param2.Value = className;
                    cmd.Parameters.Add(param2);
                    // get data stream
                    conn.Open();
                    var rdr = cmd.ExecuteXmlReader();

                    rdr.MoveToContent();
                    file = rdr.ReadOuterXml();

                    rdr.Close();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }
                    return errorMessages.ToString();
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

        public string GetWithSp(String Sql, int TimeoutSecs)
        {
            var connString = ConfigurationManager.ConnectionStrings["BoytrixWPFConn"];
            StringBuilder errorMessages = new StringBuilder();


            using (var conn = new SqlConnection(connString.ConnectionString))
            {
                string file;

                    SqlCommand cmd = new SqlCommand(Sql, conn);
                    cmd.CommandTimeout = TimeoutSecs;
                    
                    

                    try
                    {
                        conn.Open();
                        var rdr = cmd.ExecuteXmlReader();

                        rdr.MoveToContent();
                        file = rdr.ReadOuterXml();

                        rdr.Close();
                        conn.Close();

                        cmd.Dispose();
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        cmd.Dispose();
                        conn.Close();
                        conn.Dispose();
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
