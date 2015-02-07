using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Boytrix.Data.DAL.DataAccess
{
    public class PlatformDal
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


        public string GetAll(string sqlStatements)
        {
            throw new NotImplementedException();
        }

        public string Find(string sqlStatements)
        {
            throw new NotImplementedException();
        }
    }
}


            
        
    

