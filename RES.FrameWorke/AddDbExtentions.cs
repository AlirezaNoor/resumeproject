using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RES.Infrastructure.Context;

namespace RES.FrameWorke
{
    public static class AddDbExtentions
    {
        public static IServiceCollection getmyconfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("MyResume"));
            });
            return services;
        }
    }
}
