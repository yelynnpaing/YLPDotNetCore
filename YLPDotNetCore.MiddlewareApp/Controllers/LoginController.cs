using Microsoft.AspNetCore.Mvc;

namespace YLPDotNetCore.MiddlewareApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel reqModel)
        {
            HttpContext.Session.SetString("name" , reqModel.Username);
            return Redirect("/home");
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
