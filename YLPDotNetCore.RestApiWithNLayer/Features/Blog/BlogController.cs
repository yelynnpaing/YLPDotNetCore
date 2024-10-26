using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.RestApiWithNLayer.Models;

namespace YLPDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _blBlog;

        public BlogController()
        {
            _blBlog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _blBlog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _blBlog.CreateBlog(blog);
            string message = result > 0 ? "Create success." : "Create fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            var result = _blBlog.UpdateBlog(id, blog);
            string message = result > 0 ? "Update success." : "Update fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            int result = _blBlog.PatchBlog(id, blog);
            string message = result > 0 ? "Update success." : "Update fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found");
            }

            var result = _blBlog.DeleteBlog(id);
            string message = result > 0 ? "Delete success." : "Delete fail";
            return Ok(message);
        }
    }
}
