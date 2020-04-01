using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CovidDotNet.Models
{
    public partial class TimelineInfo
    {
        // extra fields
        [JsonExtensionData]
        private IDictionary<string, JToken> AdditionalProperties;
    }
}
