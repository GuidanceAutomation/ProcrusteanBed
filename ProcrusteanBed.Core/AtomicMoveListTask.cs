using ProcrusteanBed.Architecture;
using System;

namespace ProcrusteanBed.Core
{
	public class AtomicMoveListTask : AbstractListTask
	{
		public override TaskType TaskType => TaskType.AtomicMoveList;

		public override void AddSubtask(ITask subtask)
		{
			if (subtask == null) throw new ArgumentNullException("subtask");

			if (subtask.TaskType != TaskType.AtomicMove) throw new ArgumentOutOfRangeException("Subtask must be of tasktype atomic move");

			base.AddSubtask(subtask);
		}
	}
}
