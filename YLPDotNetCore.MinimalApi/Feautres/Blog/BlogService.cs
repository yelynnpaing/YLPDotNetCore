using Azure.Core;
using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.MinimalApi.Db;
using YLPDotNetCore.MinimalApi.Models;

namespace YLPDotNetCore.MinimalApi.Feautres.Blog
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder MapBlogs(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapGet("app/Blog/id", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No Data Found.");
                }
                return Results.Ok(item);
            });

            app.MapPost("api/Blog", async (AppDbContext db, BlogModel blog) =>
            {
                await db.Blogs.AddAsync(blog);
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Create success." : "Creating fail.";
                return Results.Ok(message);

            });

            app.MapPut("api/Blog/id", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found.");
                }

                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                db.Blogs.Update(item);
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Update success." : "Updating fail.";
                return Results.Ok(message);
            });

            app.MapDelete("api/Blog/id", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found.");
                }

                db.Blogs.Remove(item);
                var result = db.SaveChangesAsync();
                string message = await result > 0 ? "Delete success." : "Deleting fail.";
                return Results.Ok(message);
            });

            return app;
        }
    }
}
