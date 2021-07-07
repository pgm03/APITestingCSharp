using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace APIDemo
{
    class APIHelper
    {
        public string baseUrl = "https://petstore.swagger.io/";

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json",payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateGetRequest(string id)
        {
            var restRequest = new RestRequest(Method.GET).AddUrlSegment("petId",id);
            restRequest.AddHeader("Accept", "application/json");
            return (RestRequest)restRequest;
        }

        public RestRequest CreateDeleteRequest(string id)
        {
            var restRequest = new RestRequest(Method.DELETE).AddUrlSegment("petId", id);
            restRequest.AddHeader("Accept", "application/json");
            return (RestRequest)restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dtoObject = JsonConvert.DeserializeObject<DTO>(content);
            return dtoObject;
        }
    }
}
