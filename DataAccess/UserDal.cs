using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Boytrix.Data.DAL.DataAccess
{
    public class UserDal
    {
        public string GetUserFromDB(int UserID)
        {
            throw new NotImplementedException();
        }

        public string GetUserFromDB(string Login)
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
                        CommandText = "usp_UserGetUserXML"
                    };

                    cmd.Parameters.Add(new SqlParameter("@userName", Login));
                    cmd.Parameters.Add(new SqlParameter("@userid", 0));
                    conn.Open();
                    var rdr = cmd.ExecuteXmlReader();

                    rdr.MoveToContent();
                    file = rdr.ReadOuterXml();

                    rdr.Close();
                    conn.Close();
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

        public string GetUsersFromDB()
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
                        CommandText = "usp_User_GetUserForAddUserXML"
                    };

                    conn.Open();
                    var rdr = cmd.ExecuteXmlReader();

                    rdr.MoveToContent();
                    file = rdr.ReadOuterXml();

                    rdr.Close();
                    conn.Close();
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
