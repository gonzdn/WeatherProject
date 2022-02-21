﻿using interviewproject.api.application.Interfaces;
using interviewproject.api.application.Services;
using interviewproject.api.domain.Interfaces;
using interviewproject.api.infraestructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewProject.Configuration
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddDIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddScoped<IWeatherAppService, WeatherAppService>();
            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }
    }
}