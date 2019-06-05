using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace ProcrusteanBed.Core
{
	[DataContract]
	public class JobTemplateCollection
	{
		private ObservableCollection<JobTemplate> jobTemplates = new ObservableCollection<JobTemplate>();

		private ReadOnlyObservableCollection<JobTemplate> readonlyJobTemplates;

		[DataMember]
		public IEnumerable<JobTemplate> JobTemplates
		{
			get { return jobTemplates.ToList(); }
			set
			{
				jobTemplates.Clear();

				foreach (JobTemplate jobTemplate in value)
				{
					AddJobTemplate(jobTemplate);
				}
			}
		}

		public JobTemplateCollection()
		{
			readonlyJobTemplates = new ReadOnlyObservableCollection<JobTemplate>(jobTemplates);
		}

		public void AddJobTemplate(JobTemplate jobTemplate)
		{
			jobTemplates.Add(jobTemplate);
		}

		public ReadOnlyObservableCollection<JobTemplate> JobTemplatesOC => readonlyJobTemplates;
	}
}
