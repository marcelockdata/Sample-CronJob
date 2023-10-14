namespace WorkerService.Extensions;

public static class ScheduledServiceExtensions
{
    public static IServiceCollection AddCronJob<T>(this IServiceCollection services, Action<IScheduleConfig<T>> options) where T : WorkerService
    {
        var config = new ScheduleConfig<T>();
        options.Invoke(config);

        ////services.AddCronJob<TaskSendEmail>(c => c.CronExpression = @"0 */5 * * * *");
        ////services.AddCronJob<TaskCheckDataBase>(c => c.CronExpression = @"0 */1 * * * *");
                            
        services.AddSingleton<IScheduleConfig<T>>(config);

        services.AddHostedService<T>();

        return services;
    }
}
