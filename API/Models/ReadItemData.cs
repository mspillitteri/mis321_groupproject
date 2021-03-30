using System.Collections.Generic;
using API.Models.Interfaces;
using API.Database;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadItemData: IGetAllItems, IGetItem
    {
        public List<Item> GetAllItems() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM items ORDER BY itemname";
            var cmd = new MySqlCommand(stm, con);
            
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read()) {
                Item i = new Item(){
                    itemid = reader.GetInt32(0),
                    itemname = reader.GetString(1),
                    ischeckedout = reader.GetBoolean(2)
                    };
                items.Add(i);
            }
            return items;
        }
        // **NEEDS FIXING**
        public Item GetAnItem(int itemid) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM items WHERE itemid = @itemid";
            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemid",itemid);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            Item item = new Item(){itemid = rdr.GetInt32(0), itemname = rdr.GetString(1), ischeckedout = rdr.GetBoolean(2)};
            rdr.Close();
            return item;
        }
    }
}