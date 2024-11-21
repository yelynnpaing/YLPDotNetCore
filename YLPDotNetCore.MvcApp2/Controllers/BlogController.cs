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
            return View("BlogCreate");
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

        [HttpGet]
        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return RedirectToAction("Index");
            }
            return View("BlogEdit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogEntity blog)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Json(new {Message= "No Data Found.",  IsSuccess = false} );
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            var result = _db.SaveChanges();
            string message = result > 0 ? "Update success." : "Updating fail.";
            return Json(new { Message = message, IsSuccess = result > 0 });
        }

        [HttpPost]
        [ActionName("Delete")] 
        public IActionResult BlogDelete(BlogEntity blog)
        {
            var item = _db.Blogs.FirstOrDefault( x => x.BlogId == blog.BlogId);
            if(item is null)
            {
                return Json(new { Message = "No data Found.", IsSuccess = false });
            }

            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();
            string message = result > 0 ? "Update success." : "Updating fail.";
            return Json(new { Message = message, IsSuccess = result > 0 });
        }
    }
}
