using Newtonsoft.Json;

namespace CovidDotNet.Models
{
    public partial class Latest
    {
        [JsonProperty("confirmed", NullValueHandling = NullValueHandling.Ignore)]
        public long Confirmed { get; set; }

        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public long Deaths { get; set; }

        [JsonProperty("recovered", NullValueHandling = NullValueHandling.Ignore)]
        public long Recovered { get; set; }
    }
}
