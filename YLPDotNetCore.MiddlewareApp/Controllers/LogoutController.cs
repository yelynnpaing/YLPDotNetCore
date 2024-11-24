using Microsoft.AspNetCore.Mvc;

namespace YLPDotNetCore.MiddlewareApp.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
