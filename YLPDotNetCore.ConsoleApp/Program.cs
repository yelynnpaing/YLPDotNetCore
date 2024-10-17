
using System.Data;
using System.Data.SqlClient;
using YLPDotNetCore.ConsoleApp;

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
EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();


Console.ReadKey(); 
