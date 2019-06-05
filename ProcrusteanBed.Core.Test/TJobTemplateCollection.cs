using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProcrusteanBed.Core.Test
{
	[TestFixture]
	public class TJobTemplateCollection
	{
		[Test]
		public void ToJson_JobTemplateCollection_Empty()
		{
			JobTemplateCollection collection = new JobTemplateCollection();

			string json = JsonTools.ToJson(collection);

			Assert.IsNotNull(json);

			JobTemplateCollection obj = JsonTools.ToJobTemplateCollection(json);
			Assert.IsNotNull(obj);

			CollectionAssert.IsEmpty(obj.JobTemplates);
		}

		[Test]
		public void ToJson_JobTemplateColllection_Basic()
		{
			JobTemplateCollection collection = new JobTemplateCollection();

			collection.AddJobTemplate(Tools.CreateGoToNodeJobTemplate());

			string json = JsonTools.ToJson(collection);

			Assert.IsNotNull(json);

			JobTemplateCollection obj = JsonTools.ToJobTemplateCollection(json);
			Assert.IsNotNull(obj);

			CollectionAssert.IsNotEmpty(obj.JobTemplates);
		}
	}
}
