using System;
using System.Threading.Tasks;
using Xunit;

namespace CovidDotNet.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task GetLatest()
        {
            CovidClient c = new CovidClient();
            var latest = await c.GetLatestAsync();
            Assert.NotNull(latest);
            Assert.True(latest.Confirmed > 0);
            Assert.True(latest.Deaths > 0);
        }
    }
}
