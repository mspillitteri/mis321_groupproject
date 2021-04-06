using MySql.Data.MySqlClient;

namespace API.Models
{
    public class Add
    {
        public void AddUser(User uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO users(email, userfname, userlname, userstatus) VALUES(@email, @userfname, @userlname, @userstatus)";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@email", uvalue.email);
            cmd.Parameters.AddWithValue("@userfname", uvalue.userfname);
            cmd.Parameters.AddWithValue("@userlname", uvalue.userlname);
            cmd.Parameters.AddWithValue("@userstatus", uvalue.userstatus);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void AddItem(Item ivalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO items(itemname, itemstatus, ischeckedout) VALUES(@itemname, @itemstatus, @ischeckedout)";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemname", ivalue.itemname);
            cmd.Parameters.AddWithValue("@itemstatus", ivalue.itemstatus);
            cmd.Parameters.AddWithValue("@ischeckedout", ivalue.ischeckedout);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

    }
}