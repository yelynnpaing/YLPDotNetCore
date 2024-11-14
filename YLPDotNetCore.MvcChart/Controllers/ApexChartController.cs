using Microsoft.AspNetCore.Mvc;
using YLPDotNetCore.MvcChart.Models;

namespace YLPDotNetCore.MvcChart.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            PieChartModel model = new PieChartModel();
            model.labels = new List<string>() { "Team A", "Team B", "Team C", "Team D", "Team E" };
            model.series = new List<int>() { 44, 55, 13, 43, 22 };
            return View(model);
        }
    }
}
