using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace interviewproject.api.infraestructure.Services
{
    public class Service
    {
        private readonly HttpClient _client;

        public Service(HttpClient client)
        {
            _client = client;
        }

        protected async Task<T> ResponseProcess<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        protected async Task<HttpResponseMessage> GetRequest(string url)
        {
            _client.BaseAddress = new System.Uri(url);
            return await _client.GetAsync(string.Empty);
        }
    }
}