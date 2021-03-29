namespace API.Database
{
    public class ConnectionString
    {
        public string cs {get;set;}

        public ConnectionString() {
            string server = "g84t6zfpijzwx08q.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "iwbmu0augwse5a59";
            string port = "3306";
            string userName = "wvu2plbuaietvqt8";
            string password = "c16vbyuutxke9npf";

            cs = $@"server={server};user={userName};databse={database};port={port};password={password};";
        }
    }
}