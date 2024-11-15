using Microsoft.AspNetCore.Mvc;

namespace YLPDotNetCore.MvcChart.Controllers
{
    public class CanvasJs : Controller
    {
        private readonly ILogger<CanvasJs> _logger;

        public CanvasJs(ILogger<CanvasJs> logger)
        {
            _logger = logger;
        }

        public IActionResult LineChart()
        {
            _logger.LogInformation(" Canvasjs ... ");
            return View("LineChart");
        }
    }
}
