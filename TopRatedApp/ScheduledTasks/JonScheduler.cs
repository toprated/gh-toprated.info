using Quartz;
using Quartz.Impl;

namespace TopRatedApp.ScheduledTasks
{
    public class JobScheduler
    {
        public static void StartTop1000()
        {
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            var jobTop1000 = JobBuilder.Create<Top1000Updater>().Build();

            var trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInHours(24)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(2, 0))
                  )
                .Build();

            scheduler.ScheduleJob(jobTop1000, trigger);
        }

        public static void StartTopRatedCategories()
        {
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            var jobTopCategories = JobBuilder.Create<TopRatedCategoriesUpdater>().Build();

            var trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInHours(24)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(3, 0))
                  )
                .Build();

            scheduler.ScheduleJob(jobTopCategories, trigger);
        }
    }
}