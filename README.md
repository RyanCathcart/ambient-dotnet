# Ambient.NET

A .NET (C#) REST and WebSocket helper library for the Ambient Weather API.

Update of [ChaseDRedmon's Cirrus](https://github.com/ChaseDRedmon/Cirrus) library.

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/O4O31YN4SD)

# Table of Contents

- [Usage](#usage)
  - [REST API](#rest-api)
    - [Dependency Injection](#rest-dependency-injection)
    - [Object Creation](#rest-object-creation)
  - [Realtime (WebSocket) API](#realtime-websocket-api)
    - [Dependency Injection](#realtime-dependency-injection)
    - [Object Creation](#realtime-object-creation)

# Installation

```bash
dotnet add package RCathcart.AmbientDotNet
```

# Usage

## REST API

The REST API can be used in two ways. Dependency injection may be a little more complex to set up, but is more flexible to use throughout a project.

### 1. REST Dependency Injection

First, update `appsettings.json` with the following:

```json
{
  // ...
  "AmbientConfig": {
    "MacAddress": "<YOUR_WEATHER_STATION_MAC_ADDRESS>",
    "ApiKeys": ["<YOUR_API_KEY>", "<OR_MULTIPLE_API_KEYS>"],
    "ApplicationKey": "<YOUR_APPLICATION_KEY>"
  }
}
```

Next, update `Program.cs` with the following to add the Ambient services to the DI Container:

```csharp
using AmbientDotNet.Extensions;
using Microsoft.Extensions.Configuration;

// For Web API:
var builder = WebApplication.CreateBuilder(args);
// or for Blazor:
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// or for MAUI:
var builder = MauiApp.CreateBuilder();
// or for console app:
using Microsoft.Extensions.Hosting;
var builder = Host.CreateApplicationBuilder(args);

// Add other services to container...

builder.Services.AddAmbientServices(ambientConfig =>
{
    ambientConfig.ApiKeys = builder.Configuration
        .GetSection("AmbientConfig:ApiKeys").Get<List<string>>();

    ambientConfig.ApplicationKey = builder.Configuration
        .GetValue<string>("AmbientConfig:ApplicationKey");

    ambientConfig.MacAddress = builder.Configuration
        .GetValue<string?>("AmbientConfig:MacAddress");
});

// Add more services to container...

var app = builder.Build();
```

Finally, inject IAmbientRestApi into a class to use it:

```csharp
public class ExampleClass(IAmbientRestApi api)
{
    public async Task<IEnumerable<DeviceData>> ExampleMethod()
    {
        var result = await api.FetchDeviceDataAsync(null);
        return result;
    }
}
```

### 2. REST Object Creation

```csharp
using AmbientDotNet;

string applicationKey = "<YOUR_APPLICATION_KEY>";
string apiKey = "<YOUR_API_KEY>";
string macAddress = "<YOUR_MAC_ADDRESS>";

AmbientRestApi api = new AmbientRestApi(applicationKey, apiKey, macAddress);

IEnumerable<DeviceData> deviceData = await api.FetchDeviceDataAsync(null);

// Write to the console the JSON representation of each
// devices' data that were successfully fetched from the API
foreach (DeviceData device in deviceData)
{
    Console.WriteLine(JsonSerializer.Serialize(device,
        new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        }
    ));
}
```

## Realtime (WebSocket) API

The Realtime API can be used in two ways. Dependency injection may be a little more complex to set up, but is more flexible to use throughout a project.

### 1. Realtime Dependency Injection

First, update `appsettings.json` with the following:

```json
{
  // ...
  "AmbientConfig": {
    "MacAddress": "<YOUR_WEATHER_STATION_MAC_ADDRESS>",
    "ApiKeys": ["<YOUR_API_KEY>", "<OR_MULTIPLE_API_KEYS>"],
    "ApplicationKey": "<YOUR_APPLICATION_KEY>"
  }
}
```

Next, update `Program.cs` with the following to add the Ambient services to the DI Container:

```csharp
using AmbientDotNet.Extensions;

// For Web API:
var builder = WebApplication.CreateBuilder(args);
// or for Blazor:
var builder = WebAssemblyHostBuilder.CreateDefault(args);
// or for MAUI:
var builder = MauiApp.CreateBuilder();
// or for console app:
var builder = Host.CreateApplicationBuilder(args);

// Add other services to container...

builder.Services.AddAmbientServices(ambientConfig =>
{
    ambientConfig.ApiKeys = builder.Configuration
        .GetSection("AmbientConfig:ApiKeys").Get<List<string>>();

    ambientConfig.ApplicationKey = builder.Configuration
        .GetValue<string>("AmbientConfig:ApplicationKey");

    ambientConfig.MacAddress = builder.Configuration
        .GetValue<string?>("AmbientConfig:MacAddress");
});

// Add more services to container...

var app = builder.Build();
```

Finally, inject IAmbientRealtimeApi into a class to use it:

```csharp
public class ExampleClass(IAmbientRealtimeApi api)
{
    private readonly IAmbientRealtimeApi _api;

    public ExampleClass(IAmbientRealtimeApi api)
    {
        _api = api;

        // Define behavior when new data is received (occurs once per minute):
        api.OnDataReceived += (sender, args) =>
        {
            DeviceData? deviceData = args.DeviceData;
            string deviceJson = JsonSerializer.Serialize(deviceData,
                new JsonSerializerOptions{ WriteIndented = true });

            Console.WriteLine("New data received:");
            Console.WriteLine(deviceJson);
        };

        await _api.Connect();
    }
}
```

### 2. Realtime Object Creation

```csharp
using AmbientDotNet;

// Create the WebSocket API instance
AmbientRealtimeApi api = new AmbientRealtimeApi("<YOUR_APPLICATION_KEY>", "<YOUR_API_KEY>");

// NOTE: Instead, you can watch multiple API keys at once:
AmbientRealtimeApi api = new AmbientRealtimeApi("<YOUR_APPLICATION_KEY>",
    ["<API_KEY_1>", "<API_KEY_2>", "etc..."]);

// Define behavior when the connection is established:
api.OnConnected += (sender, args) =>
{
    Console.WriteLine("Connected to the Ambient Realtime API");
};

// Define behavior when the connection is terminated:
api.OnDisconnected += (sender, args) =>
{
    Console.WriteLine("Disconnected from the Ambient Realtime API");
};

// Define behavior when subscribed to the service:
api.OnSubscribed += (sender, args) =>
{
    User? user = args.User;
    string userJson = JsonSerializer.Serialize(user,
        new JsonSerializerOptions{ WriteIndented = true });

    Console.WriteLine("Now listening to data from the Ambient Realtime API\n" +
        "Subscriber user data received:");
    Console.WriteLine(userJson);
};

// Define behavior when new data is received (occurs once per minute):
api.OnDataReceived += (sender, args) =>
{
    DeviceData? deviceData = args.DeviceData;
    string deviceJson = JsonSerializer.Serialize(deviceData,
        new JsonSerializerOptions{ WriteIndented = true });

    Console.WriteLine("New data received:");
    Console.WriteLine(deviceJson);
};

// Finally, initiate the connection to the Ambient Realtime API:
await api.Connect();
```
