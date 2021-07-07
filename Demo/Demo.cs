namespace APIDemo
{
    public class Demo<T>
    {
        public (int statusCode,CreatePetDTO content) CreateAPet(string endpoint, string payload)
        {
            var apiHelper = new APIHelper();
            var url = apiHelper.SetUrl(endpoint);
            var request = apiHelper.CreatePostRequest(payload);
            var response = apiHelper.GetResponse(url, request);
            var statusCode = response.StatusCode;
            CreatePetDTO content = apiHelper.GetContent<CreatePetDTO>(response);
            return ((int)statusCode,content);
        }
        public (int statusCode, CreatePetDTO content) GetPet(string id, string endpoint)
        {
            var apiHelper = new APIHelper();
            var url = apiHelper.SetUrl(endpoint);
            var request = apiHelper.CreateGetRequest(id);
            var response = apiHelper.GetResponse(url, request);
            var statusCode = response.StatusCode;
            CreatePetDTO content = apiHelper.GetContent<CreatePetDTO>(response);
            return ((int)statusCode, content);
        }

        public (int statusCode, CreatePetDTO content) UpdatePet(string endpoint, string payload)
        {
            var apiHelper = new APIHelper();
            var url = apiHelper.SetUrl(endpoint);
            var request = apiHelper.CreatePutRequest(payload);
            var response = apiHelper.GetResponse(url, request);
            var statusCode = response.StatusCode;
            CreatePetDTO content = apiHelper.GetContent<CreatePetDTO>(response);
            return ((int)statusCode, content);
        }

        public (int statusCode, CreatePetDTO content) DeletePet(string id, string endpoint)
        {
            var apiHelper = new APIHelper();
            var url = apiHelper.SetUrl(endpoint);
            var request = apiHelper.CreateDeleteRequest(id);
            var response = apiHelper.GetResponse(url, request);
            var statusCode = response.StatusCode;
            CreatePetDTO content = apiHelper.GetContent<CreatePetDTO>(response);
            return ((int)statusCode, content);
        }
    }
}
