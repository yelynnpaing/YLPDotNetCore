
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using YLPDotNetCore.ConsoleApp.AdoDotNetExamples;
using YLPDotNetCore.ConsoleApp.DapperExamples;
using YLPDotNetCore.ConsoleApp.EFCoreExamples;
using YLPDotNetCore.ConsoleApp.Services;

Console.WriteLine("Hello, World!");

//for AdoDotNet
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("Sample Title", "Sample Author", "Sample Content");
//adoDotNetExample.Edit(2);
//adoDotNetExample.Edit(3);
//adoDotNetExample.Update(1, "update title", "update author", "update content");
//adoDotNetExample.Delete(2);

//for dapper
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//for EF Core 
//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();

var connecitonString = ConnectionString.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connecitonString);

var serviceProvider = new ServiceCollection()
    .AddScoped<AdoDotNetExample>(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped<DapperExample>(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connecitonString);
})
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
//adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
//dapperExample.Read();

var eFCoreExample = serviceProvider.GetRequiredService<EFCoreExample>();
eFCoreExample.Run();

AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

Console.ReadKey(); 
