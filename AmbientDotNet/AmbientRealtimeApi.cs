using AmbientDotNet.Helpers;
using AmbientDotNet.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using SocketIOClient;
using SocketIOClient.Common;
using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace AmbientDotNet;

public sealed class AmbientRealtimeApi : IAmbientRealtimeApi
{
    /// <inheritdoc cref="OnConnected"/>
    public event IAmbientRealtimeApi.OnConnectedHandler? OnConnected;

    /// <inheritdoc cref="OnDisconnected"/>
    public event IAmbientRealtimeApi.OnDisconnectedHandler? OnDisconnected;

    /// <inheritdoc cref="OnSubscribe"/>
    public event IAmbientRealtimeApi.OnSubcribedHandler? OnSubscribed;

    /// <inheritdoc cref="OnDataReceived"/>
    public event IAmbientRealtimeApi.OnDataReceivedHandler? OnDataReceived;

    private bool _disposed;
    private readonly ILogger<AmbientRealtimeApi> _log;
    private readonly List<string>? _apiKeys;
    private readonly string? _applicationKey;

    private const string BASE_ADDRESS = "https://rt2.ambientweather.net/";

    private SocketIO? Client { get; set; }

    /// <summary>
    ///    Initializes a new instance of the AmbientRealtimeApi class using the specified configuration options and optional
    ///    logger.
    /// </summary>
    /// <param name="options">The configuration options containing Ambient service settings. Cannot be null.</param>
    /// <param name="logger">The logger to use for diagnostic messages. If null, a no-op logger is used.</param>
    public AmbientRealtimeApi(IOptionsMonitor<AmbientConfig> options, ILogger<AmbientRealtimeApi>? logger = null)
    {
        _log = logger ?? NullLogger<AmbientRealtimeApi>.Instance;
        _log.LogDebug("Creating Realtime instance");

        _apiKeys = options.CurrentValue.ApiKeys;
        _applicationKey = options.CurrentValue.ApplicationKey;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="AmbientRealtimeApi"/> class with the specified application key and API keys.
    /// </summary>
    public AmbientRealtimeApi(string applicationKey, IEnumerable<string> apiKeys, ILogger<AmbientRealtimeApi>? logger = null)
    {
        _log = logger ?? NullLogger<AmbientRealtimeApi>.Instance;
        _log.LogDebug("Creating Realtime instance");

        _applicationKey = applicationKey;
        _apiKeys = [.. apiKeys];
    }

    /// <summary>
    /// Creates a new instance of the <see cref="AmbientRealtimeApi"/> class with the specified application key and API key.
    /// </summary>
    /// <param name="applicationKey">Ambient Weather Application key needed for Realtime (WebSocket) Requests.</param>
    /// <param name="apiKey">Ambient Weather API key needed for Realtime (WebSocket) Requests.</param>
    /// <param name="logger">Serilog logger.</param>
    public AmbientRealtimeApi(string applicationKey, string apiKey, ILogger<AmbientRealtimeApi>? logger = null)
    {
        _log = logger ?? NullLogger<AmbientRealtimeApi>.Instance;
        _log.LogDebug("Creating Realtime instance");

        _applicationKey = applicationKey;
        _apiKeys = [apiKey];
    }

    /// <inheritdoc />
    /// <exception cref="ArgumentException">Throws an argument exception if <see cref="_applicationKey"/> or <see cref="_apiKeys"/> is null, empty, or whitespace.</exception>
    public async Task Connect(CancellationToken token = default)
    {
        Check.IsNullOrWhitespace(_applicationKey);
        Check.AreAllNullOrWhiteSpace(_apiKeys);

        Client ??= new SocketIO(new Uri(BASE_ADDRESS), new SocketIOOptions
            {
                Query = new NameValueCollection
                {
                    ["api"] = "1",
                    ["applicationKey"] = _applicationKey,
                },
                Reconnection = true,
                ReconnectionDelayMax = 7500,
                Transport = TransportProtocol.WebSocket
            }
        );

        _log.LogInformation("Connecting to the Ambient WebSocket endpoint");

        _log.LogDebug("ApiKeys: {@Keys}", _apiKeys);

        _log.LogDebug("Subscribing event handlers");
        Client.OnConnected += OnInternalConnectEvent;
        Client.OnDisconnected += OnInternalDisconnectEvent;

        Client.On("subscribed", OnInternalSubscribedEvent);
        Client.On("data", OnInternalDataEvent);

        _log.LogInformation("Opening WebSocket connection: {BaseAddress}", BASE_ADDRESS);

        await Client.ConnectAsync(token);
        await Client.EmitAsync("connect", token);

        await Subscribe(token);
    }

    /// <inheritdoc />
    public async Task Disconnect(CancellationToken token = default)
    {
        _log.LogInformation("Closing connection to Ambient Weather WebSocket endpoint");

        await Unsubscribe(token);
        
        if (Client == null) return;

        await Client.EmitAsync("disconnect", token);
        await Client.DisconnectAsync(token);
    }

    /// <inheritdoc />
    private async Task Subscribe(CancellationToken token = default)
    {
        if (Client is null || !Client.Connected) return;

        IEnumerable<object> keys = _apiKeys == null  ? [] : [new ApiKeyWrapper(_apiKeys)];

        _log.LogInformation("Subscribing to the Ambient Weather WebSocket service");
        await Client.EmitAsync("subscribe", keys, token);
    }

    /// <inheritdoc />
    private async Task Unsubscribe(CancellationToken token = default)
    {
        if (Client is null || !Client.Connected) return;

        _log.LogInformation("Unsubscribing from the Ambient Weather WebSocket service");
        await Client.EmitAsync("unsubscribe", token);
    }

    private void OnInternalConnectEvent(object? sender, EventArgs e)
    {
        _log.LogInformation("Connected to Ambient Weather Realtime API");

        OnConnected?.Invoke(this, new OnConnectedEventArgs());
    }

    private void OnInternalDisconnectEvent(object? sender, string e)
    {
        _log.LogInformation("Disconnected from Ambient Weather Realtime API");

        OnDisconnected?.Invoke(this, new OnDisconnectedEventArgs());
    }

    private Task OnInternalSubscribedEvent(IEventContext context)
    {
        _log.LogInformation("Subscribed to WebSocket service");

        var user = context.GetValue<User>(0);

        if (user != null && user.InvalidAPIKeys != null) 
            _log.LogWarning("The following API keys were rejected by the service: {@InvalidKeys}", user.InvalidAPIKeys);

        OnSubscribed?.Invoke(this, new OnSubscribedEventArgs(user));

        return Task.CompletedTask;
    }

    private Task OnInternalDataEvent(IEventContext context)
    {
        _log.LogDebug("Received data event");

        var device = context.GetValue<DeviceData>(0);

        OnDataReceived?.Invoke(this, new OnDataReceivedEventArgs(device));

        return Task.CompletedTask;
    }

    private async ValueTask ReleaseUnmanagedResourcesAsync()
    {
        ReleaseSocketIOResources();

        await Disconnect();
    }

    private async void ReleaseUnmanagedResources()
    {
        ReleaseSocketIOResources();

        await Disconnect();
    }

    private void ReleaseSocketIOResources()
    {
        if (Client == null) return;

        // Unregister internal handlers
        Client.OnConnected -= OnInternalConnectEvent;
        Client.OnDisconnected -= OnInternalDisconnectEvent;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            // Release managed objects
            if (disposing)
            {
                // Dispose of managed resources
            }

            // Release unmanaged objects
            ReleaseUnmanagedResources();
        }

        _disposed = true;
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            // Release managed objects
            if (disposing)
            {
                // Dispose of managed resources
            }

            // Release unmanaged objects
            await ReleaseUnmanagedResourcesAsync();
        }

        _disposed = true;
    }

    ~AmbientRealtimeApi()
    {
        Dispose(false);
    }
}

public record ApiKeyWrapper(IEnumerable<string> ApiKeys)
{
    [JsonPropertyName("apiKeys")]
    public IEnumerable<string> ApiKeys { get; init; } = ApiKeys;
}
