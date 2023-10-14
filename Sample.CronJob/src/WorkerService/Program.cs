using WorkerService.Extensions;
using WorkerService.Schedulers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {       
        services.AddCronJob<TaskSendEmail>(c => c.CronExpression = @"0 */2 * * * *");
        services.AddCronJob<TaskCheckDataBase>(c => c.CronExpression = @"0 */1 * * * *");
    })
    .Build();

await host.RunAsync();
