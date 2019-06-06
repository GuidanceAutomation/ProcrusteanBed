using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core.JsonConverters
{
	public class IDirectiveConverter :JsonCreationConverter<IDirective>
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public IDirective CreateFromJObject(JObject jObject)
		{
			int enumValue = jObject.SelectToken("DirectiveType")
				.Value<int>();

			switch ((DirectiveType)enumValue)
			{
				case DirectiveType.Byte:
					return new GenericDirective<Byte>();

				case DirectiveType.Float:
					return new GenericDirective<Single>();

				case DirectiveType.IPAddress:
					return new GenericDirective<IPAddress>();

				case DirectiveType.Short:
					return new GenericDirective<Int16>();

				case DirectiveType.UShort:
					return new GenericDirective<UInt16>();

				default:
					throw new NotImplementedException();

			}
		}

		protected override IDirective Create(Type objectType, JObject jObject)
		{
			return CreateFromJObject(jObject);
		}

		private bool FieldExists(string fieldName, JObject jObject)
		{
			return jObject[fieldName] != null;
		}
	}
}
