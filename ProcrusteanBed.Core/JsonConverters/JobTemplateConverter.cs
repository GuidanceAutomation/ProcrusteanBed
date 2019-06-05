using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProcrusteanBed.Core.JsonConverters
{
	public class JobTemplateConverter : JsonCreationConverter<JobTemplate>
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public JobTemplate CreateFromJObject(JObject jObject)
		{
			return new JobTemplate();
		}

		protected override JobTemplate Create(Type objectType, JObject jObject)
		{
			return CreateFromJObject(jObject);
		}
	}
}
