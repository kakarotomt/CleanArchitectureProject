using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserApp.Application.Abstractions.Clock;
using UserApp.Application.Abstractions.Data;
using UserApp.Infrastructure.Clock;
using UserApp.Infrastructure.Data;
using UserApp.Infrastructure.Repositories;
using UsersApp.Domain.Abstractions;
using UsersApp.Domain.Users;

namespace UserApp.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDatetimeProvider, DateTimeProvider>();

            var strConn = configuration.GetConnectionString("database") ?? throw new ArgumentNullException("no se encuentra la conexion de BD");


            services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(strConn));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork>(p => p.GetRequiredService<ApplicationDbContext>());


            services.AddSingleton<ISqlConnectionFactory>( _ => new SqlConnectionFactory(strConn));
            return services;
        }

    }
}
