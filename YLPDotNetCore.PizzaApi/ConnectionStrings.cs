using Microsoft.Data.SqlClient;

namespace YLPDotNetCore.PizzaApi
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-L3SMK21\\SQLEXPRESS",
            InitialCatalog = "YLPDotNetCore",
            UserID = "sa",
            Password = "sasa@123",
            //TrustServerCertificate = true
        };
    }
}
