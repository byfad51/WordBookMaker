using System.Text;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presentations.ActionFilters;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

namespace UserSaver.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureRepositoryManager(this IServiceCollection services) => 
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
    public static void ConfigureMysqlContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("sqlConnection");
        services.AddDbContext<RepositoryContext>(options => {
            options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString), x=>x.MigrationsAssembly("UserSaver"));
        });
    }
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(opts =>
        {
            opts.Password.RequiredLength = 6;
            opts.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<RepositoryContext>().AddDefaultTokenProviders();
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var JwtSettings = configuration.GetSection("JwtSettings");
        var secretkey = JwtSettings["secretKey"];

        services.AddAuthentication(
            opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(
            opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = JwtSettings["validIssuer"],
                    ValidAudience = JwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey))
                };
            });
    }
    
    public static void ConfigureLoggerService(this IServiceCollection services) => 
        services.AddSingleton<ILoggerService, LoggerManager>();

    public static void ConfigureActionFilters(this IServiceCollection services)
    {
        services.AddScoped<ValidationFilterAttribute>();
        services.AddSingleton<LogFilterAttribute>();
    } 
}