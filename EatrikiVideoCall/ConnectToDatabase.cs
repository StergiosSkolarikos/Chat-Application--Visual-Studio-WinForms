using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EatrikiVideoCall
{
    //NEWPC\SQLEXPRESS
    
    public class ConnectToDatabase
    {
        public static SqlConnection cnn = new SqlConnection(@"Data Source = NEWPC\SQLEXPRESS; Initial Catalog = Eatriki;Integrated Security=SSPI;");
        public static void connectToDatabase()
        {
            cnn.Open();
        }
    }
}
