using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApi
{
    /// <summary>
    /// Application main entry point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main( string[] args )
        {
            CreateWebHostBuilder( args )
                .Build()
                .Run();
        }

        /// <summary>
        /// Creates a web host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder( string[] args ) =>
            WebHost.CreateDefaultBuilder( args )
                .ConfigureServices( services => services.AddAutofac() )
                .UseStartup<Startup>();
    }
}
