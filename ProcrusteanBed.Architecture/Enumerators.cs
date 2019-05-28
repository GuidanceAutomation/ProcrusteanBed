using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Architecture
{
    public enum TaskType
    {
        UnorderedList = 0,
        OrderedList = 1,
        AtomicMoveList = 2,
        GoToNode = 3,
        ServiceAtNode = 4
    };
}
