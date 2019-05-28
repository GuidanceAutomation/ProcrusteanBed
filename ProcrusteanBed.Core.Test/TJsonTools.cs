using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using ProcrusteanBed.Architecture;

namespace ProcrusteanBed.Core.Test
{
    [TestFixture]
    [Category("Json")]
    public class TJsonTools
    {
        [Test]
        public void ToJson_Job_Empty()
        {
            IJob job = new Job();
            string json = JsonTools.ToJson(job);

            Assert.IsNotNull(json);

            Job obj = JsonTools.Job(json);
            Assert.IsNotNull(obj);               
        }

        [Test]
        public void ToJson_Job_EmptyList()
        {
            int listTaskId = 66;

            Job job = new Job();

            OrderedListTask orderedListTask = new OrderedListTask();
            job.RootOrderedListTask = new OrderedListTask() { TaskId = listTaskId };

            string json = JsonTools.ToJson(job);

            Assert.IsNotNull(json);

            Job obj = JsonTools.Job(json);
            Assert.IsNotNull(obj);
            Assert.AreEqual(listTaskId, obj.RootOrderedListTaskId);
        }

        [Test]
        public void ToJson_NodeTask()
        {
            /*
            NodeTask nodeTask = new NodeTask();
            string json = JsonTools.ToJson(nodeTask);

            Assert.IsNotNull(json);

            NodeTask obj = Factory.NodeTask(json);
            Assert.IsNotNull(obj);*/
        }
    }
}
