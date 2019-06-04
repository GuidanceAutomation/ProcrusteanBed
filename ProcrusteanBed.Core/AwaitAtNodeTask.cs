using ProcrusteanBed.Architecture;
using System.Runtime.Serialization;

namespace ProcrusteanBed.Core
{
	[DataContract]
	public class AwaitAtNodeTask : AbstractNodeTask
	{
		public override TaskType TaskType => TaskType.AwaitAtNode;
	}
}
