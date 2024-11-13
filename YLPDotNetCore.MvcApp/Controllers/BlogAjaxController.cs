using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.MvcApp.Db;
using YLPDotNetCore.MvcApp.Models;

namespace YLPDotNetCore.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly AppDbContext _db;

        public BlogAjaxController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();
            return View(lst);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogCreate(BlogModel blog)
        {
            await _db.Blogs.AddAsync(blog);
            int result = await _db.SaveChangesAsync();
            string message = result > 0 ? "Create success." : "Create fail.";
            BlogMessageResoponseModel model = new BlogMessageResoponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if(item is null)
            {
                return Redirect("/BlogAjax");
            }

            return View("BlogEdit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            BlogMessageResoponseModel model = new BlogMessageResoponseModel();
            var item = await _db.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                model = new BlogMessageResoponseModel
                {
                    IsSuccess = false,
                    Message = "No data found."
                };
                return Json(model);
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            int result = await _db.SaveChangesAsync();
            string message = result > 0 ? "Updating success." : "updating fail.";

            model = new BlogMessageResoponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(BlogModel blog)
        {
            BlogMessageResoponseModel model = new BlogMessageResoponseModel();
            var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
            if(item is null)
            {
                model = new BlogMessageResoponseModel
                {
                    IsSuccess = false,
                    Message = "No data found!"
                };
                return Json(model);
            }

            _db.Blogs.Remove(item);
            int result = await _db.SaveChangesAsync();
            string message = result > 0 ? "Delete success." : "Deleting fail";
            model = new BlogMessageResoponseModel
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }
    }
}
