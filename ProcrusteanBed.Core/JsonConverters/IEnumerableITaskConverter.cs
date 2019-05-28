using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcrusteanBed.Architecture;
using Newtonsoft.Json.Linq;

namespace ProcrusteanBed.Core.JsonConverters
{
    public class IEnumerableITaskConverter : JsonConverter<List<ITask>>
    {
        public override bool CanWrite => false;

        public override List<ITask> ReadJson(JsonReader reader, Type objectType, List<ITask> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {


            ITaskConverter taskConverter = new ITaskConverter();
            


            JArray jArray = JArray.Load(reader);

            List<ITask> tasks = new List<ITask>();

            foreach (JObject jObject in jArray)
            {

                ITask task = taskConverter.CreateFromJObject(jObject);
                serializer.Populate(jObject.CreateReader(), task);

                tasks.Add(task);
            }
                                                  
            return tasks; 
        }

        public override void WriteJson(JsonWriter writer, List<ITask> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
