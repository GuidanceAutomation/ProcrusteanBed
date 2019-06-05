using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core.Test
{
	public static class Tools
	{
		public static JobTemplate CreateGoToNodeJobTemplate(int nodeId = -1)
		{
			Job job = new Job();
			job.RootOrderedListTask.AddSubtask(new GoToNodeTask() { MapItemId = nodeId });

			return new JobTemplate()
			{
				Category = "Test",
				Description = "GoTo Node",
				Site = "Generic",
				Job = job
			};
		}
	}
}
