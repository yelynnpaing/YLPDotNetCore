using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using YLPDotNetCore.NewRealtimeChartApp.Hubs;

namespace YLPDotNetCore.NewRealtimeChartApp.Controllers
{
    public class PieChartController : Controller
    {
        private readonly IHubContext<ChartHub> _hubContext;

        public PieChartController(IHubContext<ChartHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public static List<PieChartModel> Data = new List<PieChartModel>();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(PieChartModel reqModel)
        {
            Data.Add(reqModel);
            ResponsePieChartModel model = new ResponsePieChartModel()
            {
                Labels = Data.Select(x => x.Label).ToList(),
                Series = Data.Select(x => x.Series).ToList()
            };

            string jsonStr = JsonConvert.SerializeObject(model);
            await _hubContext.Clients.All.SendAsync("ClientReceiveEvent", jsonStr);
            return View();
        }

        public IActionResult Watch()
        {
            return View();
        }

    }

    public class PieChartModel
    {
        public string Label { get; set; }
        public int Series { get; set; }
    }

    public class ResponsePieChartModel
    {
        public List<string> Labels { get; set; }
        public List<int> Series { get; set; }   
    }
}
