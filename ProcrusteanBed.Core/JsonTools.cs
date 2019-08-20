using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using ProcrusteanBed.Core.JsonConverters;

namespace ProcrusteanBed.Core
{
    public static class JsonTools
    {
        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new IEnumerableITaskConverter());
			settings.Converters.Add(new IEnumerableJobTemplateConverter());
			settings.Converters.Add(new IDirectiveConverter());
			settings.Converters.Add(new IEnumerableIDirectiveConverter());
			settings.Formatting = Formatting.Indented;

            return settings;
        }

		public static IEnumerable<VehiclePose> ToVehiclePoses(string json)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.DeserializeObject<IEnumerable<VehiclePose>>(json, settings);
		}

		public static string ToJson(this VehiclePose vehiclePose)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.SerializeObject(vehiclePose, settings);
		}

		public static string ToJson(this IEnumerable<VehiclePose> vehiclePoses)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.SerializeObject(vehiclePoses, settings);
		}

		public static string ToJson(this JobTemplate jobTemplate)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.SerializeObject(jobTemplate, settings);
		}

		public static JobTemplate ToJobTemplate(string json)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.DeserializeObject<JobTemplate>(json, settings);
		}

		public static VehiclePose ToVehiclePose(string json)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.DeserializeObject<VehiclePose>(json, settings);
		}

		public static JobTemplateCollection ToJobTemplateCollection(string json)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.DeserializeObject<JobTemplateCollection>(json, settings);
		}

		public static string ToJson(this JobTemplateCollection jobTemplateCollection)
		{
			JsonSerializerSettings settings = GetJsonSerializerSettings();
			return JsonConvert.SerializeObject(jobTemplateCollection, settings);
		}

        public static Job ToJob(string json)
        {
            JsonSerializerSettings settings = GetJsonSerializerSettings();
            return JsonConvert.DeserializeObject<Job>(json, settings);
        }

        public static Job JobFromFile(string filePath)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = JsonSerializer.Create(GetJsonSerializerSettings());        
                return (Job)serializer.Deserialize(file, typeof(Job));
            }
        }

        public static string ToJson(this IJob job)
        {
            JsonSerializerSettings settings = GetJsonSerializerSettings();
            return JsonConvert.SerializeObject(job, settings);          
        }
    }
}
