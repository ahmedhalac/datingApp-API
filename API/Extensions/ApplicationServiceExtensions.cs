using System;
using API.Data;
using API.DTOs;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Web.DependencyInjection;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILikesRepository, LikesRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddImageSharp();
        services.AddScoped<LogUserActivity>();

        services.AddDbContext<DataContext>(opt =>
        opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        return services;
    }
}

