using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;
namespace API.Models
{
    public class Delete : IDelete
    {
        public void DeleteUser(int userid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM users WHERE userid= @id";

            var cmd = new MySqlCommand(stm, con); 
            cmd.Parameters.AddWithValue("@id", userid);
            cmd.Prepare();
            cmd.ExecuteNonQuery(); 
        }

        public void DeleteItem(int itemid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open(); 

            string stm = @"DELETE FROM items WHERE itemid= @id";

            var cmd = new MySqlCommand(stm, con); 
            cmd.Parameters.AddWithValue("@id", itemid);
            cmd.Prepare();
            cmd.ExecuteNonQuery(); 
        }
    }
}