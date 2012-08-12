using System;
using System.Threading;
using Quartz;
using Quartz.Impl;

namespace WebUI.AppCode
{
    public class TotalScheduler
    {
        public static void Start()
        {
            var schedFact = new StdSchedulerFactory();

            var sched = schedFact.GetScheduler();
            sched.Start();

            var jobDetail = JobBuilder.Create<HelloJob>().Build();
            var trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(x => x
                    .WithInterval(TimeSpan.FromSeconds(4))
                    .RepeatForever())
                .Build();

            sched.ScheduleJob(jobDetail, trigger); 
        }
    }

    [DisallowConcurrentExecution]
    public class HelloJob : IJob
    {
        public virtual void Execute(IJobExecutionContext context)
        {
            Thread.Sleep(TimeSpan.FromSeconds(7));
            CommonLogger.Log.Add("PING " + DateTime.Now);
        }
    }
}