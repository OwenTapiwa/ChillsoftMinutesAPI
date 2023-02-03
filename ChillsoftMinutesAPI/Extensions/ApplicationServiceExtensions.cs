using ChillsoftMinutesAPI.Data;
using ChillsoftMinutesAPI.Interfaces;
using ChillsoftMinutesAPI.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ChillsoftMinutesAPI.Helpers;
using ChillsoftMinutesAPI.Controllers;
using ChillsoftMinutesAPI.Data.Repositories;

namespace ChillsoftMinutesAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMeetingTypeRepository, MeetingTypeRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContextFactory<DataContext>(options => options.UseSqlServer(
                connectionString, sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();

                }), ServiceLifetime.Transient);
            return services;
        }

    }
}
