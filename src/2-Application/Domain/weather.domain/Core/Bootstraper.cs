using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using weather.domain.Query.v1.GetWeatherData;

namespace weather.domain.Core
{
    public static class Bootstraper
    {
        public static IServiceCollection AddDomain(this IServiceCollection service)
        {
            service.AddMediatR(typeof(GetWeatherDataCommand).GetTypeInfo().Assembly);
            service.AddTransient<IValidator<GetWeatherDataCommand>, GetWeatherDataCommandValidator>();

            return service;
        }
    }
}
