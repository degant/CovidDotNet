using System;

namespace CovidDotNet.Models
{
    public class HistoricalDataPoint
    {
        public DateTimeOffset Date { get; set; }

        public long Count { get; set; }
    }
}
