using System.Text.Json;
using AdventOfCode.Services;
using AdventOfCode.Services.Interfaces;
using Azure.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdventOfCode;

public static class Program
{
    private static async Task Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults(
                builder =>
                {
                    builder.Serializer = new JsonObjectSerializer(
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            PropertyNameCaseInsensitive = true,
                        });
                })
            .ConfigureServices(services =>
            {
                services.AddHttpClient();
                services.AddScoped<IAdventOfCodeService, AdventOfCodeService>();
                services.AddScoped<IRegexService, RegexService>();
            })
            .Build();

        await host.RunAsync();
    }
}