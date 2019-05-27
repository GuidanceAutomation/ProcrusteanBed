using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core
{
    public static class Factory
    {
        public static NodeTask NodeTask(string json)
        {
            return JsonConvert.DeserializeObject<NodeTask>(json);
        }

        public static Job Job(string json)
        {
            return JsonConvert.DeserializeObject<Job>(json);
        }

        public static Job JobFromFile(string filePath)
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (Job)serializer.Deserialize(file, typeof(Job));
            }
        }
    }
}
