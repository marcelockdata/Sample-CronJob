using WorkerService.Extensions;

namespace WorkerService.Schedulers;

public class TaskSendEmail : WorkerExtensions
{
    private readonly ILogger<TaskSendEmail> _logger;
    public TaskSendEmail(IScheduleConfig<TaskSendEmail> config, IServiceProvider serviceProvider, ILogger<TaskSendEmail> logger)
        : base(config.CronExpression, config.TimeZoneInfo, serviceProvider)
    {
        _logger = logger;
    }

    public override Task DoWork(IServiceScope scope, CancellationToken cancellationToken)
    {
        Serilog.Log.Information("Email sent!");
        _logger.LogInformation("Email sent!");
        return Task.CompletedTask;
    }
}
