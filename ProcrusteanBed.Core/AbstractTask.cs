using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProcrusteanBed.Architecture;

namespace ProcrusteanBed.Core
{
    [DataContract]
    public abstract class AbstractTask : ITask
    {
        [DataMember]
        public abstract TaskType TaskType { get; }

        private int taskId = -1;

        public int TaskId
        {
            get { return taskId; }
            set
            {
                if (taskId != value)
                {
                    taskId = value;
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
