using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBAccess
    {
        private static string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True";

        public static IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
