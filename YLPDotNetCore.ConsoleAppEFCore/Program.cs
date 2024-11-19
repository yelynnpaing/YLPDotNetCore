using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using YLPDotNetCore.ConsoleAppEFCore.Databases.Models;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
var lst = db.TblPieCharts.ToList();
foreach (var item in lst)
{
    Console.WriteLine(item.PieChartName);
    Console.WriteLine(item.PieChartValue);
    Console.WriteLine("----------------------------------");
}

Console.ReadLine();