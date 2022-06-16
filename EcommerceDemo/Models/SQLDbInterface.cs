using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EcommerceDemo.Models
{
    public class SQLDbInterface : IDisposable
    {
        #region Declare Connection string
        private readonly string connectionString = "";
        public SQLDbInterface()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SQLConnStr"].ConnectionString;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Delete
        public int deletefunction(long Id, string table_Name, string Column_name)
        {
            int ret = 0;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("update " + table_Name + " set IsActive='0' where " + Column_name + "=" + Id + "", con);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    ret = 1;
                }
            }
            catch (Exception ex)
            {

            }
            return ret;

        }
        #endregion

    }
}