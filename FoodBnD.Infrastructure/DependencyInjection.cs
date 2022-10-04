using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FoodBnD.Application.Common.Interfaces.Authentication;
using FoodBnD.Application.Common.Interfaces.Persistence;
using FoodBnD.Application.Common.Interfaces.Services;
using FoodBnD.Infrastructure.Authentication;
using FoodBnD.Infrastructure.Persistence;
using FoodBnD.Infrastructure.Services;

namespace FoodBnD.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure (
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRespository>();
        return services;
    }
}