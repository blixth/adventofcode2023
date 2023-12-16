using System.Net;
using System.Text.Json;
using AdventOfCode.Services.Interfaces;
using EnsureThat;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace AdventOfCode;

public class Day1
{
    private readonly IAdventOfCodeService _service;

    public Day1(IAdventOfCodeService service)
    {
        Ensure.Any.IsNotNull(service, nameof(service));

        _service = service;
    }

    [Function("Day1")]
    public async Task<HttpResponseData> Day1Part1(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "advent-of-code/2023/1/1")]
        HttpRequestData request)
    {
        var puzzleInput = JsonSerializer.Deserialize<IEnumerable<string>>(request.Body);
        var result = _service.GetPart1(puzzleInput ?? throw new InvalidOperationException());
        var response = request.CreateResponse();
        await response.WriteAsJsonAsync(result, HttpStatusCode.OK);

        return response;
    }
    
    [Function("Day2")]
    public async Task<HttpResponseData> Part2(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "advent-of-code/2023/1/2")]
        HttpRequestData request)
    {
        var response = request.CreateResponse();
        await response.WriteAsJsonAsync("Hello World!", HttpStatusCode.OK);
        
        return response;
    }
}