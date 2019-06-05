using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProcrusteanBed.Core.Test
{
	[TestFixture]
	public class TJobTemplate
	{
		[Test]
		public void ToJson_JobTempate_Empty()
		{
			JobTemplate jobTemplate = new JobTemplate();

			jobTemplate.Description = "Description";
			jobTemplate.Site = "Site";
			jobTemplate.Category = "Category";

			string json = JsonTools.ToJson(jobTemplate);

			Assert.IsNotNull(json);

			JobTemplate obj = JsonTools.ToJobTemplate(json);
			Assert.IsNotNull(obj);

			StringAssert.AreEqualIgnoringCase("Description", obj.Description);
			StringAssert.AreEqualIgnoringCase("Site", obj.Site);
			StringAssert.AreEqualIgnoringCase("Category", obj.Category);
		}
	}
}
