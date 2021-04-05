using System.Collections.Generic;
using API.Models.Interfaces;
using API.Database;
using MySql.Data.MySqlClient;
namespace API.Models
{
    public class ProcessReturns : IReturn
    {
        public void AddReturn(Checkouts cvalue, User uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string tempreturntime = DateTime.Now.ToString("MM/dd/yy H:mm:ss tt");

            var cmd = new MySqlCommand(stm, con);
            cmd.CommandText = @"INSERT INTO itemreturns(checkoutid, returndate) 
            VALUES(@checkoutid, @returndate, @strikecount)";

            cmd.Parameters.AddWithValue("@checkoutid", cvalue.checkoutid);
            cmd.Parameters.AddWithValue("@returndate", tempreturntime);

            cmd.CommandText = @"UPDATE checkouts SET isreturned = @isreturned WHERE checkoutid = @checkoutid";
            cmd.Parameters.AddWithValue("@isreturned", 1);

            cmd.CommandText = @"UPDATE user SET userstatus = @userstatus WHERE userid = @userid";

            if(tempreturntime > cvalue.duedate)
            {
                cmd.Parameters.AddWithValue("@userstatus", userstatus + 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@userstatus", userstatus);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}