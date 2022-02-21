using interviewproject.api.application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace interviewproject.api.application.Interfaces
{
    public interface IWeatherAppService
    {
        Task<IEnumerable<LocationSearchResponseDTO>> LocationSearch(string query);
        Task<SearchResponseDTO> Search(string woeid);
    }
}