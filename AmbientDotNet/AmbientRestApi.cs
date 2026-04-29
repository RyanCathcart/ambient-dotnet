using AmbientDotNet.Api;
using AmbientDotNet.Helpers;
using AmbientDotNet.Infrastructure;
using AmbientDotNet.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace AmbientDotNet;

public sealed class AmbientRestApi : IAmbientRestApi
{
    private readonly ILogger<AmbientRestApi> _log;
    private readonly IAmbientService _service;

    /// <inheritdoc />
    private readonly string? _apiKey;

    /// <inheritdoc />
    private readonly string? _applicationKey;

    /// <inheritdoc />
    private readonly string? _macAddress;

    /// <summary>
    /// Initializes a new instance of the <see cref="AmbientRestApi"/> class.
    /// </summary>
    /// <param name="options">Options containing MacAddress, API Key, and Application key needed for REST Requests.</param>
    /// <param name="service">HTTP Client service.</param>
    /// <param name="logger">Serilog logger.</param>
    public AmbientRestApi(IOptions<AmbientConfig> options, IAmbientService service, ILogger<AmbientRestApi>? logger = null)
    {
        _log = logger ?? NullLogger<AmbientRestApi>.Instance;
        _log.LogDebug("Creating REST instance");

        _apiKey = options.Value.ApiKeys?.First();
        _applicationKey = options.Value.ApplicationKey;
        _macAddress = options.Value.MacAddress;

        _service = service;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AmbientRestApi"/> class.
    /// This class should ONLY be used if you do not plan to add the Ambient Services in a DI container.
    /// </summary>
    /// <param name="applicationKey">Ambient Weather Application key needed for REST Requests.</param>
    /// <param name="apiKey">Ambient Weather API key needed for REST Requests.</param>
    /// <param name="macAddress">MAC Address of a Ambient Weather device.</param>
    /// <param name="logger">Serilog logger.</param>
    public AmbientRestApi(string applicationKey, string apiKey, string macAddress, ILogger<AmbientRestApi>? logger = null)
    {
        _log = logger ?? NullLogger<AmbientRestApi>.Instance;
        _log.LogDebug("Creating REST instance");

        var client = new HttpClient();
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        client.BaseAddress = new Uri("https://rt.ambientweather.net/");

        _service = new AmbientService(client);

        _applicationKey = applicationKey;
        _apiKey = apiKey;
        _macAddress = macAddress;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Device>> FetchUserDevicesAsync(CancellationToken cancellationToken = default)
    {
        return await FetchUserDevicesAsync<Device>(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> FetchUserDevicesAsync<T>(CancellationToken cancellationToken = default)
        where T : class, new()
    {
        Check.IsNullOrWhitespace(_apiKey);
        Check.IsNullOrWhitespace(_applicationKey);

        var query = string.Concat("?apiKey=", _apiKey, "&applicationKey=", _applicationKey);
        var serviceResponse = await _service.Fetch<T>(query, cancellationToken: cancellationToken);

        if (serviceResponse.Success && serviceResponse.Value != null)
            return serviceResponse.Value;

        _log.LogWarning("Unsuccessful API Response: \n {Response}", serviceResponse.ErrorMessage);
        return [];
    }

    /// <inheritdoc />
    public async Task<string> FetchUserDevicesAsJsonAsync(CancellationToken cancellationToken = default)
    {
        // Check to see if all parameters have a non-null, non-blank/whitespace value
        var serviceResponse = await FetchUserDevices(cancellationToken);

        if (serviceResponse.Success && serviceResponse.Value != null)
            return serviceResponse.Value;

        _log.LogWarning("Unsuccessful API Response: \n {Response}", serviceResponse.ErrorMessage);
        return string.Empty;
    }

    /// <inheritdoc />
    public async Task<ServiceResponse<string>> FetchUserDevices(CancellationToken cancellationToken = default)
    {
        // Check to see if all parameters have a non-null, non-blank/whitespace value
        Check.IsNullOrWhitespace(_apiKey);
        Check.IsNullOrWhitespace(_applicationKey);

        var query = string.Concat("?apiKey=", _apiKey, "&applicationKey=", _applicationKey);

        var serviceResponse = await _service.Fetch(query, cancellationToken: cancellationToken);

        if (serviceResponse.Failure)
            _log.LogWarning("Unsuccessful API Response: \n {Response}", serviceResponse.ErrorMessage);

        return serviceResponse;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<DeviceData>> FetchDeviceDataAsync(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default)
    {
        return await FetchDeviceDataAsync<DeviceData>(endDate, limit, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> FetchDeviceDataAsync<T>(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default)
        where T : class, new()
    {
        _log.LogTrace("[FetchDeviceDataAsync] MacAddress: {MacAddress}, ApiKey: {ApiKey}, ApplicationKey: {ApplicationKey}", _macAddress, _apiKey, _applicationKey);

        Check.IsNullOrWhitespace(_macAddress, nameof(_macAddress));
        Check.IsNullOrWhitespace(_apiKey, nameof(_apiKey));
        Check.IsNullOrWhitespace(_applicationKey, nameof(_applicationKey));

        if (limit <= 0) return [];

        // Build our parameters
        var query = string.Concat("?apiKey=", _apiKey, "&applicationKey=", _applicationKey, "&endDate=", endDate?.ToUniversalTime().ToUnixTimeMilliseconds(), "&limit=", limit);

        // Fetch the JSON string
        var serviceResponse = await _service.Fetch<T>(query, _macAddress, cancellationToken);

        if (serviceResponse.Success && serviceResponse.Value != null)
            return serviceResponse.Value;

        _log.LogWarning("Unsuccessful API Response: \n {Response}", serviceResponse.ErrorMessage);
        return [];
    }

    /// <inheritdoc />
    public async Task<string> FetchDeviceDataAsJsonAsync(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default)
    {
        _log.LogTrace("[FetchDeviceDataAsJsonAsync] MacAddress: {MacAddress}, ApiKey: {ApiKey}, ApplicationKey: {ApplicationKey}", _macAddress, _apiKey, _applicationKey);
        _log.LogTrace("[FetchDeviceDataAsJsonAsync] Date: {Date}, Limit: {Limit}", endDate, limit);

        var serviceResponse = await FetchDeviceDataAsServiceResponse(endDate, limit, cancellationToken);

        if (serviceResponse.Success && serviceResponse.Value != null)
            return serviceResponse.Value;

        _log.LogWarning("Unsuccessful API Response: \n {Response}", serviceResponse.ErrorMessage);
        return string.Empty;
    }

    /// <inheritdoc />
    public async Task<ServiceResponse<string>> FetchDeviceDataAsServiceResponse(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default)
    {
        _log.LogTrace("[FetchDeviceDataAsJsonAsync] MacAddress: {MacAddress}, ApiKey: {ApiKey}, ApplicationKey: {ApplicationKey}", _macAddress, _apiKey, _applicationKey);
        _log.LogTrace("[FetchDeviceDataAsJsonAsync] Date: {Date}, Limit: {Limit}", endDate, limit);

        // Check to see if all parameters have a non-null, non-blank/whitespace value
        Check.IsNullOrWhitespace(_macAddress);
        Check.IsNullOrWhitespace(_apiKey);
        Check.IsNullOrWhitespace(_applicationKey);

        if (limit <= 0)
            return ServiceResponse.Fail<string>($"{nameof(limit)} must be greater than 0");

        // Build our parameters
        var query = string.Concat("?apiKey=", _apiKey, "&applicationKey=", _applicationKey, "&endDate=", endDate?.ToUniversalTime().ToUnixTimeMilliseconds(), "&limit=", limit);

        // Query the Ambient Weather API
        var serviceResponse = await _service.Fetch(query, _macAddress, cancellationToken);

        if (serviceResponse.Failure)
            _log.LogWarning("Unsuccessful API Response: \n {Response}", serviceResponse.ErrorMessage);

        return serviceResponse;
    }

    /// <inheritdoc />
    public IAsyncEnumerable<IEnumerable<DeviceData>> FetchDeviceHistory(DateTimeOffset? startDate, DateTimeOffset? endDate, bool sliceTheListFromTheBeginningOfTheList = false, int limit = 288, CancellationToken token = default)
    {
        _log.LogTrace("Fetching device history");
        _log.LogDebug("Start Date: {StartDate}, End Date: {EndDate}, Slice: {SliceList}, Limit: {Limit}", startDate, endDate, sliceTheListFromTheBeginningOfTheList, limit);

        return FetchDeviceHistory<DeviceData>(startDate, endDate, sliceTheListFromTheBeginningOfTheList, limit, token);
    }

    /// <inheritdoc />
    public IAsyncEnumerable<IEnumerable<T>> FetchDeviceHistory<T>(DateTimeOffset? startDate, DateTimeOffset? endDate, bool sliceTheListFromTheBeginningOfTheList = false, int limit = 288, CancellationToken token = default) where T : class, new()
    {
        _log.LogTrace("Fetching device history");
        _log.LogDebug("Start Date: {StartDate}, End Date: {EndDate}, Slice: {SliceList}, Limit: {Limit}", startDate, endDate, sliceTheListFromTheBeginningOfTheList, limit);

        endDate ??= DateTimeOffset.UtcNow;

        if (endDate < startDate)
            throw new ArgumentException($"{nameof(endDate)} must be greater than {nameof(startDate)}");

        var daysBetween = endDate - startDate;
        return FetchDeviceHistory<T>(daysBetween?.Days, sliceTheListFromTheBeginningOfTheList, true, limit, token);
    }

    /// <inheritdoc />
    public IAsyncEnumerable<IEnumerable<DeviceData>> FetchDeviceHistory(TimeSpan numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, CancellationToken token = default)
    {
        return FetchDeviceHistory<DeviceData>(numberOfDaysToGoBack, sliceTheListFromTheBeginningOfTheList, includeToday, limit, token);
    }

    /// <inheritdoc />
    public IAsyncEnumerable<IEnumerable<T>> FetchDeviceHistory<T>(TimeSpan numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, CancellationToken token = default)
        where T : class, new()
    {
        _log.LogTrace("Fetching device history");
        _log.LogDebug("Days: {Days}, Slice: {Slice}, Include Today?: {Include}, Limit: {Limit}", numberOfDaysToGoBack, sliceTheListFromTheBeginningOfTheList, includeToday, limit);

        if (numberOfDaysToGoBack.Days <= 0)
            throw new ArgumentException("Value must be greater than or equal to 1", nameof(numberOfDaysToGoBack));

        return FetchDeviceHistory<T>(numberOfDaysToGoBack.Days, sliceTheListFromTheBeginningOfTheList, includeToday, limit, token);
    }

    /// <inheritdoc />
    public IAsyncEnumerable<IEnumerable<DeviceData>> FetchDeviceHistory(int? numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, CancellationToken token = default)
    {
        return FetchDeviceHistory<DeviceData>(numberOfDaysToGoBack, sliceTheListFromTheBeginningOfTheList, includeToday, limit, token);
    }

    public async IAsyncEnumerable<IEnumerable<T>> FetchDeviceHistory<T>(int? numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, [EnumeratorCancellation] CancellationToken token = default)
        where T : class, new()
    {
        _log.LogTrace("Fetching device history");
        _log.LogDebug("Days: {Days}, Slice: {Slice}, Include Today?: {Include}, Limit: {Limit}", numberOfDaysToGoBack, sliceTheListFromTheBeginningOfTheList, includeToday, limit);

        if (numberOfDaysToGoBack <= 0)
            throw new ArgumentException("Value must be greater than or equal to 1", nameof(numberOfDaysToGoBack));

        if (limit <= 0)
            yield return Enumerable.Empty<T>();

        var queryLimit = limit;

        /* Ambient weather always places the most recent event as the first element in the list.
        Older events (from earlier in the day) are at the "bottom" of the list, meaning we use TakeLast to fetch from the start of the day
        We need to query the highest amount that we can (which is 288 elements) to fetch the full day, so that we can work from the bottom up
        We don't know how many elements are actually returned until we query */
        if (sliceTheListFromTheBeginningOfTheList)
            limit = 288;

        var queryDate = includeToday ? DateTimeOffset.UtcNow : DateTimeOffset.UtcNow.AddDays(-1);

        for (var i = 0; i <= numberOfDaysToGoBack; ++i)
        {
            var result = await FetchDeviceDataAsync<T>(queryDate, limit, token);

            yield return sliceTheListFromTheBeginningOfTheList ? result.TakeLast(queryLimit) : result;
            queryDate = queryDate.AddDays(-1);
        }
    }

    /// <inheritdoc />
    public async Task<bool> DoesDeviceDataExist(DateTimeOffset? dateToCheck, CancellationToken cancellationToken = default)
    {
        // TODO: We really need a better way to handle and communicate faults to the user
        var serviceResponse = await FetchDeviceDataAsServiceResponse(dateToCheck, 1, cancellationToken);
        return !serviceResponse.Success || !serviceResponse.IsEmpty;
    }

    public void Dispose()
    {
        _service.Dispose();
    }
}
