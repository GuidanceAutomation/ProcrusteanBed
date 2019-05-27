using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core
{
    public abstract class AbstractListTask : AbstractTask, IListTask
    {
        public abstract ListTaskType ListTaskType { get; }

        private ObservableCollection<ITask> subtasks = new ObservableCollection<ITask>();

        private ReadOnlyObservableCollection<ITask> readonlySubtasks;

        public ReadOnlyObservableCollection<ITask> Subtasks => readonlySubtasks;

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
