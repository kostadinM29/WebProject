using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MedEx.Web.Tests
{
    public sealed class SeleniumServerFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        public SeleniumServerFactory()
        {
            ClientOptions.BaseAddress = new Uri("https://localhost");
            var host = WebHost.CreateDefaultBuilder(Array.Empty<string>()).UseStartup<TStartup>().Build();
            host.Start();
            RootUri = host.ServerFeatures.Get<IServerAddressesFeature>().Addresses.LastOrDefault();
            var testServer = new TestServer(new WebHostBuilder().UseStartup<FakeStartup>());
        }

        public string RootUri { get; set; }

        public class FakeStartup
        {
            public void ConfigureServices(IServiceCollection services)
            {
            }

            public void Configure()
            {
            }
        }
    }
}
