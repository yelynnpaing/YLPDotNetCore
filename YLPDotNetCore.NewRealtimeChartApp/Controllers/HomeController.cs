using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using YLPDotNetCore.NewRealtimeChartApp.Hubs;
using YLPDotNetCore.NewRealtimeChartApp.Models;

namespace YLPDotNetCore.NewRealtimeChartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ChartHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<ChartHub> hubContext = null)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(DataRequestModel requestModel)
        {
            await _hubContext.Clients.All.SendAsync("ClientReceiveEvent", requestModel.Data);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class DataRequestModel
    {
        public string Data { get; set; }
    }
}

