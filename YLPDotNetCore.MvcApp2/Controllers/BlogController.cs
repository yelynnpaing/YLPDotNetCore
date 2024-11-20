using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.MvcApp2.Database;

namespace YLPDotNetCore.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogEntity> lst = _db.Blogs.AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToList();
            return View("BlogIndex", lst);
        }

        [HttpGet]
        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("Create");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogEntity blog)
        {
            _db.Blogs.Add(blog);
            var result = _db.SaveChanges();
            string message = result > 0 ? "Create success." : "Create fail.";
            return Json(new { Message = message, IsSuccess = result > 0 });
        }
    }
}
