using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core
{
	[DataContract]
	public class GenericDirective<T> : IGenericDirective<T>
	{
		private DirectiveType directiveType;

		[DataMember]
		public DirectiveType DirectiveType => directiveType;

		private T directiveValue;

		public GenericDirective()
		{
			Type genericType = this.GetType().GetGenericArguments().First();
			directiveType = genericType.ToDirectiveType();
		}

		[DataMember]
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

		[DataMember]
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
