using interviewproject.api.application.DTO;
using interviewproject.api.domain.Model.Request;

namespace interviewproject.api.application.Extensions
{
    public static class SearchDTOExtensions
    {
        public static LocationSearchRQ ParseToLocationSearch(this LocationSearchRequestDTO model, string query)
        {
            return new LocationSearchRQ
            {
                query = query
            };
        }

        public static SearchRQ ParseToSearch(this SearchRequestDTO model, string woeid)
        {
            return new SearchRQ
            {
                woeid = woeid
            };
        }
    }
}