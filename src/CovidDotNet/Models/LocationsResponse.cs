using Newtonsoft.Json;
using System.Collections.Generic;

namespace CovidDotNet.Models
{
    public partial class LocationsResponse
    {
        [JsonProperty("latest")]
        public Latest Latest { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }
    }
}
