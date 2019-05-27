using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingClients;
using BaseClients;
using SchedulingClients.JobBuilderServiceReference;
using ProcrusteanBed.Architecture;

namespace ProcrusteanBed.Core
{
    public static class JobBuilderClient_ExtensionMethods
    {
        public static int CreateJob(this IJobBuilderClient client)
        {
            ServiceOperationResult result = client.TryCreateJob(out JobData jobData);

            return jobData.JobId;
        }

        private static void CreateListTask(this IJobBuilderClient client, OrderedListTask orderedListTask)
        {           
            switch (orderedListTask.ListTaskType)
            {


               // case ListTypeType.OrderedList:
//{
                        //client.TryCreateOrderedListTask()
                //    }

                default: throw new NotImplementedException();
            }
        }

        public static Job BuildJob(this IJobBuilderClient client, string json)
        {
            Job job = Factory.Job(json);

            job.JobId = client.CreateJob();

            client.CreateListTask(job.RootOrderedListTask);

            return job;
        }
    }
}
