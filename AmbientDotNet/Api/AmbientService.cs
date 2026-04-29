using AmbientDotNet.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AmbientDotNet.Api;

public sealed class AmbientService : IAmbientService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AmbientService> _logger;
    private bool _disposed;

    public AmbientService(HttpClient httpClient, ILogger<AmbientService>? logger = null)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? NullLogger<AmbientService>.Instance;
    }

    /// <inheritdoc />
    public async Task<ServiceResponse<IEnumerable<T>?>> Fetch<T>(string query, string? macAddress = default, CancellationToken cancellationToken = default)
        where T : class, new()
    {
        // var jsonResult = await FetchFromMemory(query, macAddress, cancellationToken);
        var path = ConstructUri(macAddress, query);
        var request = new HttpRequestMessage(HttpMethod.Get, path);

        using var responseMessage = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        await using var stream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken);
        var model = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(stream, new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        }, cancellationToken);

        return ServiceResponse.Ok(model);
    }

    /// <inheritdoc />
    public async Task<ServiceResponse<string>> Fetch(string query, string? macAddress = default, CancellationToken cancellationToken = default)
    {
        // var jsonResult = await FetchFromMemory(query, macAddress, cancellationToken);
        var path = ConstructUri(macAddress, query);
        var request = new HttpRequestMessage(HttpMethod.Get, path);

        using var responseMessage = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        await using var stream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream);
        var jsonResult = await reader.ReadToEndAsync(cancellationToken);
        return ServiceResponse.Ok(jsonResult);
    }

    /// <inheritdoc />
    /// I might play with this a bit more in the future
    /*private async Task<Memory<char>> FetchFromMemory(string query, string? macAddress = default, CancellationToken cancellationToken = default)
    {
        // Hmm, something with this code is broken and I'm not entirely sure what it is. 
        // It doesn't seem to contain the full json response because when deserialization happens, Json Serializer throws an exception saying theres no JSON tokens
        var path = ConstructUri(macAddress, query);
        var request = new HttpRequestMessage(HttpMethod.Get, path);

        using var responseMessage = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        await using var stream = await responseMessage.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream);

        var memory = default(Memory<char>);
        await reader.ReadBlockAsync(memory, cancellationToken);

        return memory;
    }*/

    private string ConstructUri(string? macAddress, string query)
    {
        const string path = "v1/devices/";
        return string.Concat(path, macAddress, query);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            // Release managed resources
            if (disposing)
            {
                _httpClient.Dispose();
            }

            // Release unmanaged resources
        }

        _disposed = true;
    }

    ~AmbientService()
    {
        Dispose(false);
    }
}
