using Microsoft.EntityFrameworkCore;
using UrlShortner.Data;

namespace UrlShortner.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();

            builder.Services
                .AddDbContext<MongoUrlContext>(options =>
                {
                    options.UseMongoDB("connection-string", "database-name");
                });
        }

        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger()
                    .UseSwaggerUI();
            }

            app.UseHttpsRedirection();
        }
    }
}
