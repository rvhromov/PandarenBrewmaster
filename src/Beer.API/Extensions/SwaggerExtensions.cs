using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Beer.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void ConfigureSwaggerDoc(this SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.SwaggerDoc(
                "v1", new OpenApiInfo {Title = "Beer.API", Version = "v1"});
        }

        public static void ConfigureSwaggerEndpoint(this SwaggerUIOptions swaggerUiOptions)
        {
            swaggerUiOptions.SwaggerEndpoint(
                "/swagger/v1/swagger.json", "Beer.API v1");
        }
    }
}