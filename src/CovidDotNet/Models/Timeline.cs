using Newtonsoft.Json;

namespace CovidDotNet.Models
{
    public partial class Timeline
    {
        [JsonProperty("latest")]
        public long Latest { get; set; }

        [JsonProperty("timeline")]
        public TimelineInfo TimelineInfo { get; set; }
    }
}
