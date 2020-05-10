namespace MapChallenge.Web.Client
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using Syncfusion.Blazor;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU0ODI2QDMxMzgyZTMxMmUzMFhWcG5rYk01TFEzUDJJcUFNekloWEl4elJhWWMxUkpNWExUaUdGYzlHcTQ9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // Services
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddBaseAddressHttpClient();

            await builder.Build().RunAsync();
        }
    }
}
