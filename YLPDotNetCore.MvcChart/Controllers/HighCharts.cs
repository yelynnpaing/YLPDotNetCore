using Microsoft.AspNetCore.Mvc;

namespace YLPDotNetCore.MvcChart.Controllers
{
    public class HighCharts : Controller
    {
        public IActionResult PieChart()
        {
            return View("PieChart");
        }
    }
}
