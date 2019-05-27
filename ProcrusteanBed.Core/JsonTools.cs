using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProcrusteanBed.Core
{
    public static class JsonTools
    {
        public static string ToJson(this IMapItemTask mapItemTask)
        {
            return JsonConvert.SerializeObject(mapItemTask);
        }
                
        public static string ToJson(this IJob job)
        {
            return JsonConvert.SerializeObject(job);
        }
    }
}
