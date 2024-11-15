using Serilog;
using System.Runtime.InteropServices;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/YLPDotNetCore.ConsoleAppLogging.txt",
        rollingInterval: RollingInterval.Hour,
        rollOnFileSizeLimit: true)
    .CreateLogger();

Log.Debug("Hello");
Log.Fatal("Hello World");
Log.Information("Hello");

try
{
    // Your program here...
    const string name = "Serilog";
    Log.Information("Hello, {Name}!", name);
    throw new InvalidOperationException("Oops...");
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandled exception");
}
finally
{
    await Log.CloseAndFlushAsync(); // ensure all logs written before app exits
}


