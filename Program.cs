using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CatFactAzFunc.Services;
using CatFactAzFunc.Interfaces;

namespace CatFactAzFunc
{
    public class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services => {
                    services.AddSingleton<ICatFactService, CatFactService>();
                })
                .Build();
            // Initialize service before first service call
            host.Services.GetService<ICatFactService>();
            await host.RunAsync();
        }
    }
}