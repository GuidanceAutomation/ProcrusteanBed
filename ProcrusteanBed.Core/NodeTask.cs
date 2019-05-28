using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core
{
    public class NodeTask : AbstractMapItemTask
    {
        public override TaskType TaskType => TaskType.NodeTask;
    }
}
