using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Architecture
{
    public interface IServiceAtNodeTask : INodeTask
    {
        IEnumerable<IDirective> Directives { get; set; }

        void AddDirective(IDirective directive);
    }
}
