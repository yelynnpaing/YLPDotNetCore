using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.RestApiWithNLayer.Models;

namespace YLPDotNetCore.RestApiWithNLayer.DB
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
