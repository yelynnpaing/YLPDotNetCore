using Microsoft.AspNetCore.Mvc;

namespace YLPDotNetCore.MvcChart.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult BarChart()
        {
            return View("BarChart");
        }

        public IActionResult LineChart()
        {
            return View("LineChart");
        }
    }
}
