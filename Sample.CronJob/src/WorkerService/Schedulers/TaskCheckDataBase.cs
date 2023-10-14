using WorkerService.Extensions;

namespace WorkerService.Schedulers;

public class TaskCheckDataBase : WorkerExtensions
{
    private readonly ILogger<TaskCheckDataBase> _logger;
    public TaskCheckDataBase(IScheduleConfig<TaskCheckDataBase> config, IServiceProvider serviceProvider, ILogger<TaskCheckDataBase> logger)
        : base(config.CronExpression, config.TimeZoneInfo, serviceProvider)
    {
        _logger = logger;
    }
    public override Task DoWork(IServiceScope scope, CancellationToken cancellationToken)
    {
        Serilog.Log.Information("Verified Database!");
        _logger.LogInformation("Verified Database!");
        return Task.CompletedTask;
    }
}
