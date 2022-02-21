using interviewproject.api.application.DTO;
using interviewproject.api.application.Interfaces;
using interviewproject.api.domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace interviewproject.api.application.Services
{
    public class WeatherAppService : IWeatherAppService
    {
        private readonly IWeatherService _weatherService;
        public WeatherAppService(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IEnumerable<LocationSearchResponseDTO>> LocationSearch(string query)
        {
            return null;
        }

        public async Task<SearchResponseDTO> Search(string woeid)
        {
            return null;
        }
    }
}