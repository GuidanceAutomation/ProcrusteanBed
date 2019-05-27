using ProcrusteanBed.Architecture;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ProcrusteanBed.Core
{
    [DataContract]
    public class Job : IJob
    {
        private int jobId = -1;

        public int JobId
        {
            get { return jobId; }
            set
            {
                if (jobId != value)
                {
                    jobId = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        private OrderedListTask rootOrderedListTask = new OrderedListTask();

        [DataMember]
        public OrderedListTask RootOrderedListTask
        {
            get { return rootOrderedListTask; }
            set
            {
                if (rootOrderedListTask != value)
                {
                    rootOrderedListTask = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public int RootOrderedListTaskId => rootOrderedListTask == null ? -1 : rootOrderedListTask.TaskId;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
