using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class MySQL
    {
        public MySqlConnection GetConnection() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            return con;
        }
    }
}