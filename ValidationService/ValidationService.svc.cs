using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml;

namespace ValidationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ValidationService : IValidationService
    {
        /* The service method modifed to return objects of type CustomErrorType instead of System.String */
        public bool ValidateShippingMethod(string shippingMethodName, out ICollection<CustomErrorType> validationErrors)
        {
            validationErrors = new List<CustomErrorType>();
            int count = 0;
            /* query database as before */

            if (count > 0)
                validationErrors.Add(new CustomErrorType("The supplied ShippingMethodName is already in use. Please choose another one.", Severity.ERROR));

            /* Verifying that length of username */
            if (shippingMethodName.Length > 10 || shippingMethodName.Length < 4)
                validationErrors.Add(new CustomErrorType("The shippingMethodName should be between 4 and 10 characters long.", Severity.WARNING));

            /* Verifying that the username contains only letters */
            if (!Regex.IsMatch(shippingMethodName, @"^[a-zA-Z]+$"))
                validationErrors.Add(new CustomErrorType("The shippingMethodName must only contain letters (a-z, A-Z).", Severity.ERROR));

            return validationErrors.Count == 0;
        }

        public string GetModuleValidation(int moduleId)
        {
            ConnectionStringSettings connString = ConfigurationManager.ConnectionStrings["BoytrixWPFConn"];

            if (connString == null)
            {
                throw new ConfigurationErrorsException("The Connection String BoytrixWPFConn is missing!");
            }

            using (var conn = new SqlConnection(connString.ConnectionString))
            {
                string moduleValidationData;

                try
                {
                    var cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "usp_EH_GetModuleValidation"
                    };

                    cmd.Parameters.Add(new SqlParameter("@ModuleID", moduleId));
                    conn.Open();
                    XmlReader rdr = cmd.ExecuteXmlReader();
                    rdr.MoveToContent();
                    moduleValidationData = rdr.ReadOuterXml();
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

                return moduleValidationData;
            }
        }
    }
}
