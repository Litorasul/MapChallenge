namespace MapChallenge.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using MapChallenge.Client.Game;
    using MapChallenge.Client.Infrastructure;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using Syncfusion.Blazor;

    using static MapChallenge.Shared.Keys;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionBlazorKey);
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient(
                "MapChallenge.ServerAPI",
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

                // .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MapChallenge.ServerAPI"));

            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddApiAuthorization();

            builder.Services.AddSingleton<IGameStartInfo, GameStartInfo>();
            builder.Services.AddTransient<IApiClient, ApiClient>();
            builder.Services.AddTransient<IGameEngine, GameEngine>();

            await builder.Build().RunAsync();
        }
    }
}
