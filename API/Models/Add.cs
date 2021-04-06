namespace API.Models
{
    public class Add
    {
        AddUser(User uvalue)
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
        AddItem(Item ivalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO items(itemname, itemstatus, ischeckedout) VALUES(@itemname, @itemstatus, @ischeckedout)";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemname", ivalue.itemvalue);
            cmd.Parameters.AddWithValue("@itemstatus", uvalue.itemstatus);
            cmd.Parameters.AddWithValue("@ischeckedout", uvalue.ischeckedout);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

    }
}