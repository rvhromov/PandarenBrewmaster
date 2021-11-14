using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using User.API.Extensions;
using User.API.Filters;
using User.BusinessLogic.MapperProfiles;
using User.Infrastructure.Extensions;
using User.Infrastructure.MigrationRunners;

namespace User.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => c.ConfigureSwaggerDoc());
            services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

            services.AddAutoMapper(typeof(UserProfile), typeof(MapperProfiles.UserProfile));
            
            services.AddAppDbContext(Configuration.GetConnectionString("AppDbContext"));
            services.RegisterTypes(Configuration);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.ConfigureSwaggerEndpoint());
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            MigrationRunner.ApplyMigrations(app.ApplicationServices);
        }
    }
}