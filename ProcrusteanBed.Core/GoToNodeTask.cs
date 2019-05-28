using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcrusteanBed.Architecture;

namespace ProcrusteanBed.Core
{
    public class GoToNodeTask : AbstractNodeTask
    {
        public override TaskType TaskType => TaskType.GoToNode;
    }
}
