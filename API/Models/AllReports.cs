using API.Models.Interfaces;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class AllReports : IReport
    {
         public List<Item> ReportInventory()
         {
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
                    itemstatus = reader.GetString(2),
                    ischeckedout = reader.GetBoolean(3)
                    };
                items.Add(i);
            }
            return items;
         }
         public List<CheckedOutItems> ReportCheckedOutItems()
         {
             ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT items.itemid, itemname, duedate FROM items JOIN checkouts ON checkouts.itemid = items.itemid WHERE ischeckedout = 1 ORDER BY duedate";
            var cmd = new MySqlCommand(stm, con);
            
            MySqlDataReader reader = cmd.ExecuteReader();
            List<CheckedOutItems> items = new List<CheckedOutItems>();
            while (reader.Read()) {
                CheckedOutItems i = new CheckedOutItems(){
                    itemid = reader.GetInt32(0),
                    itemname = reader.GetString(1),
                    duedate = reader.GetDateTime(2)
                    };
                items.Add(i);
            }
            return items;
         }
    }
}