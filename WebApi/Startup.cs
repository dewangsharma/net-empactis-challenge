using Autofac.Extensions.DependencyInjection;
using BusinessLogic.Concrete;
using BusinessLogic.Contracts;
using Core.Model.Mappers;
using DataAccess.Concrete;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WebApi.Extensions;

namespace WebApi
{
    public class Startup
    {
        const string ServiceName = "EmpactisChallenge";
        public const string CORS_POLICY_NAME = "AllowAnyOrigin";

        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddDbContext<EFDBContext>( opt => opt.UseInMemoryDatabase( ServiceName ) );

            services.AddScoped<IEmployeeAbsenceService, EmployeeAbsenceService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAbsenceRepository, AbsenceRepository>();

            // Add autofac            
            services.AddAutofac();

            services.AddAutoMapper( Assembly.GetAssembly( typeof( IMap ) ),
                Assembly.GetAssembly( typeof( Mappers.IMap ) ) );

            // Services
            services.AddControllers();

            // Cors
            services.SetupCORS();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors( CORS_POLICY_NAME );
            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );

            // Post service bindings
            using( var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope() )
            {
                // Get the db context
                var context = serviceScope.ServiceProvider.GetService<EFDBContext>();

                // Seed data
                context.SeedData( );
            }
        }
    }
}
