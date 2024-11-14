using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using YLPDotNetCore.MvcChart.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult LineChart()
        {
           List<Series> seriesList = new List<Series>()
           {
               new Series("Series A", new List<double>{ 1.4, 2, 2.5, 1.5, 2.5, 2.8, 3.8, 4.6 } ),
               new Series("Series B", new List<double>{20, 29, 37, 36, 44, 45, 50, 58})
           };

            List<int> categories = new List<int>() { 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016 };

            LineChartModel model = new LineChartModel(seriesList, categories);
            return View(model);
        }
    }
}


