using CovidDotNet.Core;
using CovidDotNet.Exceptions;
using CovidDotNet.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CovidDotNet
{
    public class CovidClient
    {
        private string baseUrl = "https://coronavirus-tracker-api.herokuapp.com/";
        private IRestClient client;

        public CovidClient(string baseUrl = null)
            : base()
        {
            if (!string.IsNullOrEmpty(baseUrl))
            {
                this.baseUrl = baseUrl;
            }

            this.client = new RestClient(this.baseUrl)
                .UseSerializer(() => new JsonNetSerializer());
        }

        internal CovidClient(IRestClient client)
        {
            this.client = client;
        }

        public async Task<Latest> GetLatestAsync(DataSource? source = default)
        {
            var request = new RestRequest(Constants.Apis.Latest, Method.GET);
            AddDataSourceIfPresent(request, source);

            var response = await this.client.ExecuteAsync<LatestResponse>(request);
            ThrowOnFailure(response);

            return response.Data?.Latest;
        }

        public async Task<IList<Location>> GetLocationsAsync(DataSource? source = default, string countryCode = null, string province = null, string county = null, bool includeTimelines = false)
        {
            var request = new RestRequest(Constants.Apis.Locations, Method.GET);
            AddDataSourceIfPresent(request, source);
            AddQueryParameterIfNotEmpty(request, Constants.Apis.QueryParams.CountryCode, countryCode);
            AddQueryParameterIfNotEmpty(request, Constants.Apis.QueryParams.Province, province);
            AddQueryParameterIfNotEmpty(request, Constants.Apis.QueryParams.County, county);
            request.AddQueryParameter(Constants.Apis.QueryParams.IncludeTimelines, includeTimelines.ToString());

            var response = await this.client.ExecuteAsync<LocationsResponse>(request);
            ThrowOnFailure(response);

            return response.Data?.Locations;
        }

        public async Task<Location> GetLocationAsync(long id, DataSource? source = default, bool includeTimeline = false)
        {
            var request = new RestRequest(string.Format(Constants.Apis.LocationsById, id), Method.GET);
            AddDataSourceIfPresent(request, source);
            request.AddQueryParameter(Constants.Apis.QueryParams.IncludeTimelines, includeTimeline.ToString());

            var response = await this.client.ExecuteAsync<LocationResponse>(request);
            ThrowOnFailure(response);

            return response.Data?.Location;
        }

        private static void ThrowOnFailure<T>(IRestResponse<T> response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CovidApiException($"Failed to get a succesful response from the server. Received {response.StatusCode} with message {response.Content}");
            }
        }

        private static void AddQueryParameterIfNotEmpty(RestRequest request, string name, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                request.AddQueryParameter(name, value);
            }
        }

        private static void AddDataSourceIfPresent(RestRequest request, DataSource? source)
        {
            if (source != null)
            {
                request.AddQueryParameter(Constants.Apis.QueryParams.Source, source.ToString().ToLowerInvariant());
            }
        }
    }
}
