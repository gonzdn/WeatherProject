namespace interviewproject.api.domain.Config
{
    public class JWTConfig
    {
        public string Secret { get; set; }
        public int ExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}