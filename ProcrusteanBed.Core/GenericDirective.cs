using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core
{
    public class GenericDirective<T> : IDirective
    {
        private T directiveValue;

        public T DirectiveValue
        {
            get { return directiveValue; }
            set
            {
                directiveValue = value;
                OnNotifyPropertyChanged();           
            }
        }

        private string parameterAlias = string.Empty;

        public string ParameterAlias
        {
            get { return parameterAlias; }
            set
            {
                if (parameterAlias != value)
                {
                    parameterAlias = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
