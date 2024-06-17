using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaGestion.Data
{
    public static class ConnectionADO
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
