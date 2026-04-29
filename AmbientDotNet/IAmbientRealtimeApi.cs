using AmbientDotNet.Models;

namespace AmbientDotNet;

public interface IAmbientRealtimeApi : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Handler for the OnConnected event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="token">Hands a <see cref="JToken"/> from the websocket.</param>
    delegate void OnConnectedHandler(object sender, OnConnectedEventArgs token);

    /// <summary>
    /// The OnConnected event fires when a successful connection is reached with the Ambient Weather WebSocket server
    /// </summary>
    event OnConnectedHandler OnConnected;

    /// <summary>
    /// Handler for the OnDisconnected event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="token">Hands a <see cref="JToken"/> from the websocket.</param>
    delegate void OnDisconnectedHandler(object sender, OnDisconnectedEventArgs token);

    /// <summary>
    /// The OnDisconnected event fires when the connection is closed with the Ambient Weather WebSocket server
    /// </summary>
    event OnDisconnectedHandler OnDisconnected;

    /// <summary>
    /// Handler for the OnSubcribed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="token">Hands a <see cref="JToken"/> from the websocket.</param>
    delegate void OnSubcribedHandler(object sender, OnSubscribedEventArgs token);

    /// <summary>
    /// The OnSubcribed event fires when a successful subscription is negotiated with the Ambient Weather WebSocket server
    /// </summary>
    event OnSubcribedHandler OnSubscribed;

    /// <summary>
    /// Handler for the OnDataReceived event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="token">Hands a <see cref="JToken"/> from the websocket.</param>
    delegate void OnDataReceivedHandler(object sender, OnDataReceivedEventArgs token);

    /// <summary>
    /// The OnDataReceived Event fires when it receives an event from the Ambient Weather API
    /// </summary>
    event OnDataReceivedHandler OnDataReceived;

    /// <summary>
    /// Opens a connection and subscribes to the Ambient Weather service
    /// </summary>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Returns a <see cref="Task"/>.</returns>
    /// <exception cref="ArgumentException">Throws an argument exception if <see cref="AmbientConfig.ApplicationKey"/> or <see cref="AmbientConfig.ApiKeys"/> is null, empty, or whitespace.</exception>
    Task Connect(CancellationToken token = default);

    /// <summary>
    /// Unsubscribes from the Ambient Weather Service and closes the SocketIO connection
    /// </summary>
    /// <returns>Returns a <see cref="Task"/>.</returns>
    /// <param name="token">Cancellation token.</param>
    Task Disconnect(CancellationToken token = default);
}

public record OnConnectedEventArgs();

public record OnDisconnectedEventArgs();

public record OnSubscribedEventArgs(User? User);

public record OnDataReceivedEventArgs(DeviceData? DeviceData);
