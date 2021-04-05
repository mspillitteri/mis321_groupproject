using System.Collections.Generic;
using API.Models.Interfaces;
using API.Database;
using MySql.Data.MySqlClient;
namespace API.Models
{
    public class ProcessCheckouts : ICheckout
    {
        public void AddCheckout(Item ivalue, User uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string tempcheckouttime = DateTime.Now.ToString("MM/dd/yy H:mm:ss tt");
            string tempdue = tempcheckouttime.AddDays(14);
            var cmd = new MySqlCommand(stm, con);
            
            cmd.CommandText = @"INSERT INTO checkouts(itemid, userid, checkouttime, duedate, isreturned) 
            VALUES(@itemid, @userid, @checkouttime, @duedate, @isreturned)";
            cmd.Parameters.AddWithValue("@itemid", ivalue.itemid);
            cmd.Parameters.AddWithValue("@userid", uvalue.userid);
            cmd.Parameters.AddWithValue("@checkouttime", tempcheckouttime);
            cmd.Parameters.AddWithValue("@duedate", tempTime);
            cmd.Parameters.AddWithValue("@isreturned", 0);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}