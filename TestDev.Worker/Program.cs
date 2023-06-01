using TestDev.Worker;
using TestDev.Worker.Interfaces;
using TestDev.Worker.Queues;
using TestDev.Worker.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IBackgroundTaskQueue>(ctx => 
            new BackgroundTaskQueue(20));
        services.AddSingleton<MonitorLoop>();
        services.AddHostedService<QueuedHostedService>();
    })
    .Build();

var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
monitorLoop.StartMonitorLoop();
host.Run();
