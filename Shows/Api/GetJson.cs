using Shows.Models;

namespace Shows.Api
{
    public class GetJson
    {
        private readonly HttpClient _httpClient;

        public GetJson(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Data?> GetDataAsync(string url)
        {
            var response = await _httpClient.GetFromJsonAsync<Data>(url);
            return response;
        }
    }
}

