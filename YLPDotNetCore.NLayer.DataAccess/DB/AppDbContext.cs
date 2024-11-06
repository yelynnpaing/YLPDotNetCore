using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.NLayer.DataAccess.Models;

namespace YLPDotNetCore.NLayer.DataAccess.DB
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
