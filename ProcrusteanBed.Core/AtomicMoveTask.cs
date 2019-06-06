using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcrusteanBed.Architecture;

namespace ProcrusteanBed.Core
{
	public class AtomicMoveTask : AbstractMapItemTask
	{
		public override TaskType TaskType => TaskType.AtomicMove;
	}
}
