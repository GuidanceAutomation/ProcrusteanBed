using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingClients;
using BaseClients;
using SchedulingClients.JobBuilderServiceReference;
using ProcrusteanBed.Architecture;
using MoreLinq;

namespace ProcrusteanBed.Core
{
    public static class JobBuilderClient_ExtensionMethods
    {
        public static JobData CreateJob(this IJobBuilderClient client)
        {
            ServiceOperationResult result = client.TryCreateJob(out JobData jobData);
            return jobData;
        }

        private static void CreateGoToNodeTask(this IJobBuilderClient client, AbstractNodeTask nodeTask, int parentTaskId)
        {
            ServiceOperationResult result = client.TryCreateGoToNodeTask(parentTaskId, nodeTask.MapItemId, out int moveTaskId);
            nodeTask.MapItemId = moveTaskId;       
        }

        private static void CreateMapItemTask(this IJobBuilderClient client, IMapItemTask mapItemTask, int parentTaskId)
        {
            switch (mapItemTask)
            {
                case GoToNodeTask goToNodeTask:
                    {
                        CreateGoToNodeTask(client, goToNodeTask, parentTaskId);
                        break;
                    }

                default:
                    throw new NotImplementedException();
            }

        }

        private static void CreateTask(this IJobBuilderClient client, ITask task, int parentTaskId)
        {
            switch(task)
            {
                case IListTask listTask:
                    {
                        CreateListTask(client, listTask);
                        break;
                    }

                case IMapItemTask mapItemTask:
                    {
                        CreateMapItemTask(client, mapItemTask, parentTaskId);
                        break;
                    }

                default:
                    throw new NotImplementedException();
            }
        }

        private static void CreateListTask(this IJobBuilderClient client, IListTask listTask)
        {
            throw new NotImplementedException();

            switch (listTask.TaskType)
            {
                case TaskType.OrderedList:
                    {
                        break;
                    }

                default: throw new NotImplementedException();
            }
        }

        public static Job BuildJobFromFile(this IJobBuilderClient client, string filePath)
        {
            throw new NotImplementedException();
        }

        public static Job BuildJobFromJson(this IJobBuilderClient client, string json)
        {
            Job job = JsonTools.ToJob(json);

            JobData jobData = client.CreateJob();

            job.JobId = jobData.JobId;
            job.RootOrderedListTask.TaskId = jobData.RootOrderedListTaskId;

            job.RootOrderedListTask.Subtasks
                .ForEach(e => CreateTask(client, e, job.RootOrderedListTask.TaskId));

            ServiceOperationResult result = client.TryCommit(job.JobId, out bool success);
            
            return job;
        }
    }
}
