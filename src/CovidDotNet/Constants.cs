using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDotNet
{
    static class Constants
    {
        internal static class Apis
        {
            internal const string Latest = "v2/latest";
            internal const string Locations = "v2/locations";
            internal const string LocationsById = "v2/locations/{0}";
            internal const string Sources = "v2/sources";

            internal static class QueryParams
            {
                internal const string Source = "source";
                internal const string CountryCode = "country_code";
                internal const string Province = "province";
                internal const string County = "county";
                internal const string IncludeTimelines = "timelines";
            }
        }
    }
}
