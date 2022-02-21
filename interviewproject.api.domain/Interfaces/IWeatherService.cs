using interviewproject.api.domain.Model.Request;
using interviewproject.api.domain.Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace interviewproject.api.domain.Interfaces
{
    public interface IWeatherService
    {
        Task<IEnumerable<LocationSearchRS>> LocationSearch(LocationSearchRQ model);
        Task<SearchRS> Search(SearchRQ model);
    }
}