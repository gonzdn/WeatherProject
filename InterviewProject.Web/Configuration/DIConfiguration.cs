using interviewproject.api.application.Interfaces;
using interviewproject.api.application.Services;
using interviewproject.api.domain.Config;
using interviewproject.api.domain.Interfaces;
using interviewproject.api.infraestructure.Services;
using InterviewProject.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http;

namespace InterviewProject.Configuration
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WeatherAPI>(configuration.GetSection(APIConstants.WeatherAPISection));

            services.AddScoped<IWeatherAppService, WeatherAppService>();
            services.AddHttpClient<IWeatherService, WeatherService>().AddPolicyHandler(GetRetryPolicy());

            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .RetryAsync(3);
        }
    }
}