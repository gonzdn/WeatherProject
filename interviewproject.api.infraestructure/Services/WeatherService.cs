using interviewproject.api.domain.Interfaces;
using interviewproject.api.domain.Model.Request;
using interviewproject.api.domain.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace interviewproject.api.infraestructure.Services
{
    public class WeatherService : IWeatherService
    {
        
        public WeatherService()
        {
            
        }

        public async Task<IEnumerable<LocationSearchRS>> LocationSearch(LocationSearchRQ model)
        {
            return null;
        }

        public async Task<SearchRS> Search(SearchRQ model)
        {
            return null;
        }
    }
}