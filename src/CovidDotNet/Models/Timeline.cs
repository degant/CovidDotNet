using CovidDotNet.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CovidDotNet.Models
{
    public partial class Timeline
    {
        [JsonProperty("latest")]
        public long Latest { get; set; }

        [JsonProperty("timeline")]
        [JsonConverter(typeof(HistoricalDataConverter))]
        public List<HistoricalDataPoint> History { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> AdditionalProperties;
    }
}
