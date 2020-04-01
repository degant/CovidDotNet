using CovidDotNet.Models;
using Moq;
using RestSharp;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CovidDotNet.Tests
{
    public class CovidClientUnitTests
    {
        public CovidClientUnitTests()
        {

        }

        [Fact]
        public async Task GetLocationsAsync()
        {
            var restClientMock = MockRestClient(HttpStatusCode.OK, new LocationsResponse());
            var client = new CovidClient(restClientMock);
            var locations = await client.GetLocationsAsync();
            Assert.Null(locations);
        }

        public static IRestClient MockRestClient<TResponse>(HttpStatusCode httpStatusCode, TResponse response)
            where TResponse : new()
        {
            var restResponse = new Mock<IRestResponse<TResponse>>();
            restResponse.Setup(_ => _.StatusCode).Returns(httpStatusCode);
            restResponse.Setup(_ => _.Data).Returns(response);

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient
              .Setup(x => x.ExecuteAsync<TResponse>(It.IsAny<IRestRequest>(), default(CancellationToken)))
              .ReturnsAsync(restResponse.Object);
            return mockRestClient.Object;
        }
    }
}
