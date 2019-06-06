using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;

namespace ProcrusteanBed.Core.JsonConverters
{
	public class IEnumerableIDirectiveConverter : JsonConverter<List<IDirective>>
	{
		public override bool CanWrite => false;

		public override List<IDirective> ReadJson(JsonReader reader, Type objectType, List<IDirective> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			IDirectiveConverter converter = new IDirectiveConverter();

			List<IDirective> directives = new List<IDirective>();

			foreach (JObject jObject in JArray.Load(reader))
			{

				IDirective directive = converter.CreateFromJObject(jObject);
				serializer.Populate(jObject.CreateReader(), directive);

				directives.Add(directive);
			}

			return directives;
		}

		public override void WriteJson(JsonWriter writer, List<IDirective> value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
