namespace API.Models
{
    public class Checkouts
    {
        public int checkoutid{get; set;}
        public int itemid{get; set;}
        public int userid{get; set;}
        public string checkouttime{get; set;}
        public string duedate{get; set;}
        public bool isreturned{get; set;}

    }
}