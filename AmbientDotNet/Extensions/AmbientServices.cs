using AmbientDotNet.Api;
using AmbientDotNet.Models;
using Microsoft.Extensions.DependencyInjection;
using Polly.Registry;

namespace AmbientDotNet.Extensions;

public static class AmbientServices
{
    /// <summary>
    /// Adds all internal services required by the Ambient library
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="setupAction">Ambient configuration class for API Keys, MacAddresses, and Application Key</param>
    /// <returns>Service Collection.</returns>
    public static IServiceCollection AddAmbientServices(this IServiceCollection services, Action<AmbientConfig> setupAction)
    {
        var policyRegistry = new PolicyRegistry
        {
            { nameof(Policies.GetRetryPolicy), Policies.GetRetryPolicy() },
            { nameof(Policies.CheckAuthorizedPolicy), Policies.CheckAuthorizedPolicy() },
            { nameof(Policies.GetCircuitBreakerPolicy), Policies.GetCircuitBreakerPolicy() },
            { nameof(Policies.GetTooManyRequestsPolicy), Policies.GetTooManyRequestsPolicy() }
        };

        services
            .Configure(setupAction)
            .AddTransient<LoggingContext>()
            .AddScoped<Limiter>()
            .AddScoped<IAmbientRealtimeApi, AmbientRealtimeApi>()
            .AddScoped<IAmbientRestApi, AmbientRestApi>()
            .AddPolicyRegistry(policyRegistry);

        services
            .AddHttpClient<IAmbientService, AmbientService>(nameof(AmbientService), client =>
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.BaseAddress = new Uri("https://rt.ambientweather.net/");
            })
            .AddHttpMessageHandler<LoggingContext>()
            .AddHttpMessageHandler<Limiter>()
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan)
            .AddPolicyHandlerFromRegistry(nameof(Policies.GetRetryPolicy))
            .AddPolicyHandlerFromRegistry(nameof(Policies.CheckAuthorizedPolicy))
            .AddPolicyHandlerFromRegistry(nameof(Policies.GetCircuitBreakerPolicy))
            .AddPolicyHandlerFromRegistry(nameof(Policies.GetTooManyRequestsPolicy));

        return services;
    }
}
