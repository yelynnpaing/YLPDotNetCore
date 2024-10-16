
using System.Data;
using System.Data.SqlClient;
using YLPDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.read();
//adoDotNetExample.create("Sample Title", "Sample Author", "Sample Content");
//adoDotNetExample.edit(2);
//adoDotNetExample.edit(3);
//adoDotNetExample.update(1, "update title", "update author", "update content");
//adoDotNetExample.delete(2);

//for dapper
DapperExample dapperExample = new DapperExample();
dapperExample.run();


Console.ReadKey(); 
