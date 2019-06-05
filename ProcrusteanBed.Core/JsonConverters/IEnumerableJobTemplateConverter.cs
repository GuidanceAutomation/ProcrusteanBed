using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core.JsonConverters
{
	public class IEnumerableJobTemplateConverter : JsonConverter<List<JobTemplate>>
	{
		public override bool CanWrite => false;

		public override List<JobTemplate> ReadJson(JsonReader reader, Type objectType, List<JobTemplate> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JobTemplateConverter jobTemplateConverter = new JobTemplateConverter();

			List<JobTemplate> jobTemplates = new List<JobTemplate>();

			foreach (JObject jObject in JArray.Load(reader))
			{
				JobTemplate jobTemplate = jobTemplateConverter.CreateFromJObject(jObject);
				serializer.Populate(jObject.CreateReader(), jobTemplate);
				jobTemplates.Add(jobTemplate);
			}

			return jobTemplates;
		}

		public override void WriteJson(JsonWriter writer, List<JobTemplate> value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
