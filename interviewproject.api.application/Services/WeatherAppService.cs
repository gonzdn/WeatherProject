using interviewproject.api.application.DTO;
using interviewproject.api.application.Extensions;
using interviewproject.api.application.Interfaces;
using interviewproject.api.domain.Interfaces;
using Mapster;
using System;
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
            try
            {
                var model = new LocationSearchRequestDTO();
                var request = model.ParseToLocationSearch(query);
                var response = await _weatherService.LocationSearch(request);
                return response.Adapt<IEnumerable<LocationSearchResponseDTO>>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SearchResponseDTO> Search(string woeid)
        {
            try
            {
                var model = new SearchRequestDTO();
                var request = model.ParseToSearch(woeid);
                var response = await _weatherService.Search(request);
                return response.Adapt<SearchResponseDTO>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}