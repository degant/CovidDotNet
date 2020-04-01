using System.Threading.Tasks;
using Xunit;

namespace CovidDotNet.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task GetLatestAsync()
        {
            CovidClient c = new CovidClient();
            var latest = await c.GetLatestAsync();
            Assert.NotNull(latest);
            Assert.True(latest.Confirmed > 0);
            Assert.True(latest.Deaths > 0);
        }

        [Fact]
        public async Task GetLocationsAsync()
        {
            CovidClient c = new CovidClient();
            var locations = await c.GetLocationsAsync();
            Assert.NotNull(locations);
            Assert.NotEmpty(locations);
            Assert.True(locations.Count > 80);
        }

        [Fact]
        public async Task GetLocationAsync()
        {
            CovidClient c = new CovidClient();
            var location = await c.GetLocationAsync(12, includeTimeline: true);
            Assert.NotNull(location);
            Assert.Equal(12, location.Id);
            Assert.NotNull(location.Timelines);
            Assert.NotNull(location.Timelines.Confirmed);
            Assert.NotEmpty(location.Timelines.Confirmed.History);
        }
    }
}
