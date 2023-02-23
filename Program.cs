using DotNetWindowsServiceDemo;
using Serilog;


var progData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(Path.Combine(progData,"CourseDemos","servicelog.txt"))
    .CreateLogger();
IHost host = Host.CreateDefaultBuilder(args)
.UseWindowsService()
.UseSerilog()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
