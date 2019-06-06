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

        private static void CreateGoToNodeTask(this IJobBuilderClient client, GoToNodeTask nodeTask, int parentTaskId)
        {
            ServiceOperationResult result = client.TryCreateGoToNodeTask(parentTaskId, nodeTask.MapItemId, out int goToTaskId);
            nodeTask.TaskId = goToTaskId;       
        }

		private static void CreateServiceAtNodeTask(this IJobBuilderClient client, ServiceAtNodeTask serviceAtNodeTask, int parentTaskId)
		{
			ServiceOperationResult result = client.TryCreateServicingTask(parentTaskId, serviceAtNodeTask.MapItemId, serviceAtNodeTask.ServiceType, out int serviceTaskId);
			serviceAtNodeTask.TaskId = serviceTaskId;

			foreach(IDirective directive in serviceAtNodeTask.Directives)
			{
				switch (directive.DirectiveType)
				{
					case DirectiveType.Byte:
						{
							IGenericDirective<byte> byteDirective = (IGenericDirective<byte>)directive;
							client.TryIssueDirective(serviceTaskId, directive.ParameterAlias, byteDirective.DirectiveValue);
							break;
						}

					default:
						throw new NotImplementedException();
				}
			}
		}

		private static void CreateAtomicMoveTask(this IJobBuilderClient client, AtomicMoveTask atomicMoveTask, int parentTaskId)
		{
			ServiceOperationResult result = client.TryCreateAtomicMoveTask(parentTaskId, atomicMoveTask.MapItemId, out int atomicMoveTaskId);
			atomicMoveTask.TaskId = atomicMoveTaskId;
		}

		private static void CreateMapItemTask(this IJobBuilderClient client, IMapItemTask mapItemTask, int parentTaskId)
        {
            switch (mapItemTask)
            {
				case AtomicMoveTask atomicMoveTask:
					{
						CreateAtomicMoveTask(client, atomicMoveTask, parentTaskId);
						break;
					}

                case GoToNodeTask goToNodeTask:
                    {
                        CreateGoToNodeTask(client, goToNodeTask, parentTaskId);
                        break;
                    }

				case ServiceAtNodeTask serviceAtNodeTask:
					{
						CreateServiceAtNodeTask(client, serviceAtNodeTask, parentTaskId);
						break;
					}

                default:
                    throw new NotImplementedException();
            }

        }

		private static void CreateAtomicMoveListTask(this IJobBuilderClient client, AbstractListTask listTask, int parentTaskId)
		{
			client.TryCreateAtomicMoveListTask(parentTaskId, out int listTaskId);
			listTask.TaskId = listTaskId;		
		}

        private static void CreateTask(this IJobBuilderClient client, ITask task, int parentTaskId)
        {
            switch(task)
            {
                case AbstractListTask listTask:
                    {
                        CreateListTask(client, listTask, parentTaskId);
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



        private static void CreateListTask(this IJobBuilderClient client, AbstractListTask listTask, int parentTaskId)
        {
            switch (listTask.TaskType)
            {
                case TaskType.AtomicMoveList:
                    {
						CreateAtomicMoveListTask(client, listTask, parentTaskId);
                        break;
                    }

                default: throw new NotImplementedException();
            }

			listTask.Subtasks.ForEach(e => CreateTask(client, e, listTask.TaskId));
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
