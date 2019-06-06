using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Architecture
{
	public interface IGenericDirective<T> : IDirective
	{
		T DirectiveValue { get; set; }
	}
}
