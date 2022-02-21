using interviewproject.api.domain.Config;
using interviewproject.api.domain.Interfaces;
using interviewproject.api.domain.Model.Request;
using interviewproject.api.domain.Model.Response;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace interviewproject.api.infraestructure.Services
{
    public class WeatherService : Service, IWeatherService
    {
        private readonly WeatherAPI _weatherAPI;
        public WeatherService(IOptions<WeatherAPI> weatherAPI)
        {
            _weatherAPI = weatherAPI.Value;
        }

        public async Task<IEnumerable<LocationSearchRS>> LocationSearch(LocationSearchRQ model)
        {
            var response = await GetRequest($"{_weatherAPI.LocationSearch}{model.query}");
            return await ResponseProcess<IEnumerable<LocationSearchRS>>(response);
        }

        public async Task<SearchRS> Search(SearchRQ model)
        {
            var response = await GetRequest($"{_weatherAPI.Search}{model.woeid}");
            return await ResponseProcess<SearchRS>(response);
        }
    }
}