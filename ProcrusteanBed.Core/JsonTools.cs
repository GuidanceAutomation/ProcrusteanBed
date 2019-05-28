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
           // settings.TypeNameHandling = TypeNameHandling.Objects;
            settings.Converters.Add(new JsonConverters.IEnumerableITaskConverter());
        //    settings.Converters.Add(new JsonConverters.ITaskConverter());

            return settings;
        }

        public static Job Job(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
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
