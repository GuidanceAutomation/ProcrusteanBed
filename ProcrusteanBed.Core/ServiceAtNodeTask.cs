using ProcrusteanBed.Architecture;
using SchedulingClients.JobBuilderServiceReference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace ProcrusteanBed.Core
{
    [DataContract]
    public class ServiceAtNodeTask : AbstractNodeTask
    {
        private ServiceType serviceType = ServiceType.Execution;

        public override TaskType TaskType => TaskType.ServiceAtNode;

        private ObservableCollection<IDirective> directives = new ObservableCollection<IDirective>();

        private ReadOnlyObservableCollection<IDirective> readonlyDirectives;

        public ReadOnlyObservableCollection<IDirective> DirectivesOC => readonlyDirectives;

        [DataMember]
        public ServiceType ServiceType
        {
            get { return serviceType; }
            set
            {
                if (serviceType != value)
                {
                    serviceType = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        [DataMember]
        public IEnumerable<IDirective> Directives
        {
            get { return directives.ToList(); }
            set
            {
                directives.Clear();

                foreach (IDirective directive in value)
                {
                    directives.Add(directive);
                }
            }
        }

        public void AddDirective(IDirective directive)
        {
            directives.Add(directive);
        }

        public ServiceAtNodeTask()
        {
            readonlyDirectives = new ReadOnlyObservableCollection<IDirective>(directives);
        }
    }
}
