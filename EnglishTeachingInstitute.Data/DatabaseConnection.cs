using Habanero.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTeachingInstitute.Data
{
    public class DatabaseConnection
    {
        private string connectionString = null;
        protected SqlConnection connection;
        protected SqlCommand sqlCommand;
        protected SqlDataReader sqlDataReader;

        public DatabaseConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionName"].ToString();
            connection = new SqlConnection(connectionString);
        }

    }
   
}
