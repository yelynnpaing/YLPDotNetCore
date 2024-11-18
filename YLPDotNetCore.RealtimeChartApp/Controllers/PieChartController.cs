using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using YLPDotNetCore.RealtimeChartApp.Hubs;
using YLPDotNetCore.RealtimeChartApp.Models;

namespace YLPDotNetCore.RealtimeChartApp.Controllers
{
    public class PieChartController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHubContext<ChartHub> _hubContext;

        public PieChartController(AppDbContext db, IHubContext<ChartHub> hubContext)
        {
            _db = db;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public async Task<IActionResult> Save(TblPieChart reqModel)
        {
            await _db.TblPieCharts.AddAsync(reqModel);
            await _db.SaveChangesAsync();

            var lst = await _db.TblPieCharts.AsNoTracking().ToListAsync();
            var data = lst.Select(x => new PiechartDataModel
            {
                name = x.PieChartName,
                y = x.PieChartValue
            }).ToList();

            await _hubContext.Clients.All.SendAsync("ReceivePieChart", data);
            return RedirectToAction("Index");
        }
    }
}

public class PiechartDataModel
{
    public string name { get; set; }    
    public decimal y { get; set; }
}