using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace interviewproject.api.infraestructure.Services
{
    public class Service
    {
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
            var http = new HttpClient();
            http.BaseAddress = new System.Uri(url);
            return await http.GetAsync(string.Empty);
        }
    }
}