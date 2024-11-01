using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YLPDotNetCore.WinFormsApp
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-L3SMK21\\SQLEXPRESS",
            InitialCatalog = "YLPDotNetCore",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };
    }
}
