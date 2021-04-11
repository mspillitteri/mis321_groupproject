using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;
namespace API.Models
{
    public class Update : IUpdate
    {
        public void UpdateCheckOut(Checkouts cvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE checkouts SET duedate = @duedate WHERE cvalue = @checkoutid";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@duedate", cvalue.duedate);
            cmd.Parameters.AddWithValue("@checkoutid", cvalue.checkoutid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void UpdateItem(Item ivalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE items SET itemname = @itemname, itemstatus = @itemstatus, ischeckedout = @ischeckedout WHERE ivalue = @itemid";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemname", ivalue.itemname);
            cmd.Parameters.AddWithValue("@itemstatus", ivalue.itemstatus);
            cmd.Parameters.AddWithValue("@ischeckedout", ivalue.ischeckedout);
            cmd.Parameters.AddWithValue("@itemid", ivalue.itemid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void UpdateUser(User uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE users SET email = @email, userfname = @userfname, userlname = @userlname, userstatus = @userstatus WHERE uvalue = @userid";

            var cmd = new MySqlCommand(stm, con);
            
            cmd.Parameters.AddWithValue("@email", uvalue.email);
            cmd.Parameters.AddWithValue("@userfname", uvalue.userfname);
            cmd.Parameters.AddWithValue("@userlname", uvalue.userlname);
            cmd.Parameters.AddWithValue("@userstatus", uvalue.userstatus);
            cmd.Parameters.AddWithValue("@userid", uvalue.userid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}