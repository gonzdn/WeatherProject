namespace interviewproject.api.application.DTO
{
    public class LocationSearchRequestDTO
    {
        public string query { get; set; }
    }
    public class LocationSearchResponseDTO
    {
        public string title { get; set; }
        public string location_type { get; set; }
        public int woeid { get; set; }
        public string latt_long { get; set; }
    }
}