using Newtonsoft.Json;
using System.Collections.Generic;

namespace CovidDotNet.Models
{
    public partial class LocationResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
