using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public static class DALHelper
    {
        private static readonly string connectionString = "Server=localhost;Database=SchoolPlatform;Integrated Security=SSPI;TrustServerCertificate=True";
        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
