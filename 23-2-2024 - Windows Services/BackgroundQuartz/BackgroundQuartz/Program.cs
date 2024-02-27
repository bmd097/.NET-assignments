using BackgroundQuartz;
using Quartz.Impl;
using Quartz.Spi;
using Quartz;
using Microsoft.Extensions.DependencyInjection;

Host.CreateDefaultBuilder()
    .ConfigureServices((services) => {
        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
        var scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
        var jobDetail = JobBuilder.Create<MyJob>()
            .WithIdentity("myJob", "group1").Build();
        var trigger = TriggerBuilder.Create()
            .WithIdentity("myTrigger", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(5)
                .WithRepeatCount(2)) // .RepeatForever()
            .Build();
        scheduler.ScheduleJob(jobDetail, trigger).GetAwaiter().GetResult();
        scheduler.Start().GetAwaiter().GetResult();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        scheduler.Shutdown().GetAwaiter().GetResult();
    })
    .Build().Run();
