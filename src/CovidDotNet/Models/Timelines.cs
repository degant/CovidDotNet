using Newtonsoft.Json;

namespace CovidDotNet.Models
{
    public partial class Timelines
    {
        [JsonProperty("confirmed")]
        public Timeline Confirmed { get; set; }

        [JsonProperty("deaths")]
        public Timeline Deaths { get; set; }

        [JsonProperty("recovered")]
        public Timeline Recovered { get; set; }
    }
}
