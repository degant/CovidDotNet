using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDotNet.Models
{
    public partial class LatestResponse
    {
        [JsonProperty("latest")]
        public Latest Latest { get; set; }
    }
}
