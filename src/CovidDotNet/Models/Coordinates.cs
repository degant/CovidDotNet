using Newtonsoft.Json;

namespace CovidDotNet.Models
{
    public partial class Coordinates
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }
}
