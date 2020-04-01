using CovidDotNet.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CovidDotNet.Core
{
    internal class HistoricalDataConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not implemented yet");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var historyInfo = new List<HistoricalDataPoint>();
            foreach (var dataPoint in obj)
            {
                if (DateTimeOffset.TryParse(dataPoint.Key, out var result))
                {
                    var count = (long)dataPoint.Value;
                    var h = new HistoricalDataPoint() { Date = result, Count = count };
                    historyInfo.Add(h);
                }
                else
                {
                    // TODO: Log?
                }
            }

            return historyInfo;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
