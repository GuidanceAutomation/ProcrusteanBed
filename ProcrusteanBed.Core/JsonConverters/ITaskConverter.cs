﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcrusteanBed.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcrusteanBed.Core.JsonConverters
{
    public class ITaskConverter : JsonCreationConverter<ITask>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public ITask CreateFromJObject(JObject jObject)
        {
            int enumValue = jObject.SelectToken("TaskType")
                .Value<int>();

            switch ((TaskType)enumValue)
            {
                case TaskType.OrderedList:
                    return new OrderedListTask();

                case TaskType.GoToNode:
                    return new GoToNodeTask();

                default:
                    throw new NotImplementedException();
            }
        }

        protected override ITask Create(Type objectType, JObject jObject)
        {
            return CreateFromJObject(jObject);    
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
}
