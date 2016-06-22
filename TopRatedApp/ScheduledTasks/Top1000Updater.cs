using Quartz;
using TopRatedApp.Helpers;

namespace TopRatedApp.ScheduledTasks
{
    public class Top1000Updater : IJob
    {
        public async void Execute(IJobExecutionContext context)
        {
            var c = await GitHubHelper.GetClient();
        }
    }
}