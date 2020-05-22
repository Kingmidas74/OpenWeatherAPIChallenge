using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWeatherClient(this IServiceCollection services)
        {
            services.AddHttpClient<WeatherClient>(client =>
            {
                //?appid={Environment.GetEnvironmentVariable (nameof (EnvironmentVariables.API_KEY))}
                client.BaseAddress = new Uri(
                    $"{Environment.GetEnvironmentVariable (nameof (EnvironmentVariables.API_URL))}");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));                

            });
            return services;
        }
    }
}