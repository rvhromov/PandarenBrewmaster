using Beer.API.Data;
using Beer.API.Services.Beer;
using Beer.API.Services.Feedback;
using Beer.API.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Beer.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterTypes(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(
                configuration.GetSection(nameof(DatabaseSettings)));
            
            services.AddSingleton(sp => 
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddSingleton<IMongoClient>(sp => 
                new MongoClient(sp.GetRequiredService<IOptions<DatabaseSettings>>().Value.ConnectionString));

            services.AddScoped<MongoDbContext>();

            services.AddTransient<IBeerService, BeerService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
        }
    }
}