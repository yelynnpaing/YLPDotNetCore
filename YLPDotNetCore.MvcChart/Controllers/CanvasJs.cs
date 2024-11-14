using Microsoft.AspNetCore.Mvc;

namespace YLPDotNetCore.MvcChart.Controllers
{
    public class CanvasJs : Controller
    {
        public IActionResult LineChart()
        {
            return View("LineChart");
        }
    }
}
