using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Setup cors configuration
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection SetupCORS( this IServiceCollection services )
        {
            services.AddCors( options =>
            {
                // Allow anyone to call the api
                options.AddPolicy( Startup.CORS_POLICY_NAME,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                );
            } );
            //services.Configure<MvcOptions>( options =>
            //{
            //    // Add the cors authorisation filter
            //    options.Filters.Add( new CorsAuthorizationFilterFactory( Startup.CORS_POLICY_NAME ) );
            //} );
            return services;
        }
    }
}
