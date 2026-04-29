using AmbientDotNet.Infrastructure;

namespace AmbientDotNet.Api;

/// <summary>
/// HTTP Client Service for sending REST Requests to the Ambient Weather Server
/// </summary>
public interface IAmbientService : IDisposable
{
    /// <summary>
    /// Submits a request to the Ambient Weather API
    /// </summary>
    /// <typeparam name="T"> The type that resulting JSON will be deserialized to.</typeparam>
    /// <param name="query"> Ambient Weather API query.</param>
    /// <param name="macAddress">The weather station MAC Address.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns> A deserialized JSON <see cref="IEnumerable{T}"/> response from the Ambient Weather API.</returns>
    Task<ServiceResponse<IEnumerable<T>?>> Fetch<T>(string query, string? macAddress = default, CancellationToken cancellationToken = default)
        where T : class, new();

    /// <summary>
    /// Submits a request to the Ambient Weather API
    /// </summary>
    /// <param name="query"> Ambient Weather API query.</param>
    /// <param name="macAddress">The weather station MAC Address.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns> JSON <see cref="string"/> from the Ambient Weather API.</returns>
    Task<ServiceResponse<string>> Fetch(string query, string? macAddress = default, CancellationToken cancellationToken = default);
}
