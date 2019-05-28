using ProcrusteanBed.Architecture;
using SchedulingClients.JobBuilderServiceReference;
using System.Runtime.Serialization;

namespace ProcrusteanBed.Core
{
    [DataContract]
    public class ServiceAtNodeTask : AbstractNodeTask
    {
        private ServiceType serviceType = ServiceType.Execution;

        public override TaskType TaskType => TaskType.ServiceAtNode;

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
    }
}
