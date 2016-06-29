using System.Diagnostics;
using Octokit;
using Quartz;
using TopRatedApp.Common.BadgeClasses;
using TopRatedApp.Helpers;

namespace TopRatedApp.ScheduledTasks
{
    public class Top1000Updater : IJob
    {
        public /*async*/ void Execute(IJobExecutionContext context)
        {
            /*var c = await GitHubHelper.GetClient();
            Debug.Write("EXECUTING!!!!!!!!!!");
            foreach (var l in Languages.All)
            {
                var repos = c.Search.SearchRepo(new SearchRepositoriesRequest
                {
                    Language = l.OctokitLanguage
                }).Result.Items;
            }*/
        }
    }
}