using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ConnectionDB
    {
        public static string GetConnection()
        {
            string connectionString = "Server=.; Database= DButronHospital; Trusted_Connection=True; User ID=sa; Password=pass@word1; TrustServerCertificate=true;";
            return connectionString;
        }
    }
}
