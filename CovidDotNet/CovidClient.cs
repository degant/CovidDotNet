using CovidDotNet.Models;
using RestSharp;
using System.Threading.Tasks;

namespace CovidDotNet
{
    public class CovidClient
    {
        private const string baseUrl = "https://coronavirus-tracker-api.herokuapp.com/";
        private IRestClient client = new RestClient(baseUrl);

        public async Task<Latest> GetLatestAsync()
        {
            var request = new RestRequest("v2/latest", Method.GET);
            var response = await this.client.ExecuteAsync<LatestResponse>(request);
            if (!response.IsSuccessful)
            {
                // TODO: Throw exception
            }

            return response.Data?.Latest;
        }
    }
}
