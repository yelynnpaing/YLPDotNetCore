using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.BlazorServerApp.Models;

namespace YLPDotNetCore.BlazorServerApp.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<BlogModel> Blogs { get; set; }
    }
}
