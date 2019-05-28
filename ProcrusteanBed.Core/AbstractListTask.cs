using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core
{
    [DataContract]
    public abstract class AbstractListTask : AbstractTask, IListTask
    {

        private ObservableCollection<ITask> subtasks = new ObservableCollection<ITask>();

        private ReadOnlyObservableCollection<ITask> readonlySubtasks;

        public ReadOnlyObservableCollection<ITask> SubtasksOC => readonlySubtasks;

        [DataMember]
        public IEnumerable<ITask> Subtasks
        {
            get { return subtasks.ToList(); }
            set
            {
                subtasks.Clear();      

                foreach(ITask subTask in value)
                {
                    subtasks.Add(subTask);
                }
            }
        }

        public void AddSubtask(ITask subtask)
        {
            subtasks.Add(subtask);
        }

        public AbstractListTask()
        {
            readonlySubtasks = new ReadOnlyObservableCollection<ITask>(subtasks);
        }
    }
}
