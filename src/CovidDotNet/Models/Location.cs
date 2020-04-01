using Newtonsoft.Json;

namespace CovidDotNet.Models
{
    public partial class Location
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_population", NullValueHandling = NullValueHandling.Ignore)]
        public long CountryPopulation { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("latest")]
        public Latest Latest { get; set; }

        [JsonProperty("timelines")]
        public Timelines Timelines { get; set; }
    }
}
