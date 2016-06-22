using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using TopRatedApp.ScheduledTasks;

namespace TopRatedApp.Common
{
    public static class DataGetter
    {
        public static string AppDataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        public static string ClientDataPath => Path.Combine(AppDataPath, "clientData.json");

        public static async Task<ClientData> GetClientData()
        {
            using (var reader = File.OpenText(ClientDataPath))
            {
                var fileText = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<ClientData>(fileText);
            }
        }

        public static async Task<Top1000Data> GetTop1000(string langApiName)
        {
            try
            {
                var path = Path.Combine(AppDataPath, $"{langApiName}.json");
                using (var reader = File.OpenText(path))
                {
                    var fileText = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<Top1000Data>(fileText);
                }
            }
            catch (Exception)
            {
                var scheduler = StdSchedulerFactory.GetDefaultScheduler();
                scheduler.Start();

                var job = JobBuilder.Create<Top1000Updater>().Build();

                var trigger = (ISimpleTrigger)TriggerBuilder.Create()
                    .StartNow()
                    .Build();
                //TriggerBuilder.Create()
                //.StartNow().Build();

                scheduler.ScheduleJob(job, trigger);
                return null;
            }
        }
    }
}