using AmbientDotNet.Infrastructure;
using AmbientDotNet.Models;

namespace AmbientDotNet;

public interface IAmbientRestApi : IDisposable
{
    /// <summary>
    ///     Fetch a list of devices and device metadata associated with the user's account and the most recent weather data for each device
    /// </summary>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>
    /// Returns an IEnumerable of <see cref="Device" /> objects.
    /// If the result does not have a success status code, returns an empty <see cref="IEnumerable{Device}"/>
    /// </returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/> or
    /// <see cref="ApplicationKey"/> are null, empty, or whitespace
    /// </exception>
    Task<IEnumerable<Device>> FetchUserDevicesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Fetch a list of devices and device metadata associated with the user's account and the most recent weather data for each device
    /// </summary>
    /// <typeparam name="T"> A User Device Data POCO. </typeparam>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>
    /// Returns an IEnumerable of <see cref="T" /> objects.
    /// If the result does not have a success status code, returns an empty <see cref="IEnumerable{Device}"/>
    /// </returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/> or
    /// <see cref="ApplicationKey"/> are null, empty, or whitespace
    /// </exception>
    Task<IEnumerable<T>> FetchUserDevicesAsync<T>(CancellationToken cancellationToken = default)
        where T : class, new();

    /// <summary>
    ///     Fetch a list of devices and device metadata associated with the user's account and the most recent weather data for each device
    /// </summary>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>Returns a JSON string. </returns>
    /// <returns>If the result does not have a success status code, returns an empty string.</returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/> or
    /// <see cref="ApplicationKey"/> are null, empty, or whitespace
    /// </exception>
    Task<string> FetchUserDevicesAsJsonAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Fetch a list of devices and device metadata associated with the user's account and the most recent weather data for each device
    /// </summary>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>Returns a string wrapped in a <see cref="ServiceResponse{T}"/>.</returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/> or
    /// <see cref="ApplicationKey"/> are null, empty, or whitespace
    /// </exception>
    Task<ServiceResponse<string>> FetchUserDevices(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Fetches a Weather Station's data based on its MAC Address from the Ambient Weather API
    /// </summary>
    /// <param name="endDate">Date to query information for; if <see cref="endDate"/> is null, then the Ambient Weather API will return data for the current date.</param>
    /// <param name="limit">
    ///     The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items
    ///     is 1 day's worth of data.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>Returns a <see cref="DeviceData" /> object.</returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/>,
    /// <see cref="ApplicationKey"/>, or <see cref="MacAddress"/> are null, empty, or whitespace
    /// </exception>
    Task<IEnumerable<DeviceData>> FetchDeviceDataAsync(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Fetches a Weather Station's data based on its MAC Address from the Ambient Weather API
    /// </summary>
    /// <typeparam name="T"> A Device Data POCO. </typeparam>
    /// <param name="endDate">Date to query information for; if <see cref="endDate"/> is null, then the Ambient Weather API will return data for the current date.</param>
    /// <param name="limit">
    ///     The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items
    ///     is 1 day's worth of data.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>Deserializes a JSON String and returns an <see cref="IEnumerable{T}" /> object.</returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/>,
    /// <see cref="ApplicationKey"/>, or <see cref="MacAddress"/> are null, empty, or whitespace
    /// </exception>
    Task<IEnumerable<T>> FetchDeviceDataAsync<T>(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default)
        where T : class, new();

    /// <summary>
    ///     Fetches a Weather Station's data based on its MAC Address from the Ambient Weather API
    /// </summary>
    /// <param name="endDate">
    /// Date to query information for; if <see cref="endDate"/> is null,
    /// then the Ambient Weather API will return data for the current date
    /// </param>
    /// <param name="limit">
    ///     The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items
    ///     is 1 day's worth of data.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>Returns a JSON string.</returns>
    /// <returns>If data does not exist for a given day or an error is thrown, returns an empty string.</returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/>,
    /// <see cref="ApplicationKey"/>, or <see cref="MacAddress"/> are null, empty, or whitespace
    /// </exception>
    Task<string> FetchDeviceDataAsJsonAsync(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Fetches a Weather Station's data based on its MAC Address from the Ambient Weather API
    /// </summary>
    /// <param name="endDate">
    /// Date to query information for; if <see cref="endDate"/> is null,
    /// then the Ambient Weather API will return data for the current date
    /// </param>
    /// <param name="limit">
    ///     The amount of items to return. Maximum is 288. Items are in 5 minute increments, meaning 288 items
    ///     is 1 day's worth of data.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>Returns a JSON string wrapped in a <see cref="ServiceResponse{T}"/>.</returns>
    /// <returns>If data does not exist for a given day or an error is thrown, returns an empty string.</returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/>,
    /// <see cref="ApplicationKey"/>, or <see cref="MacAddress"/> are null, empty, or whitespace
    /// </exception>
    Task<ServiceResponse<string>> FetchDeviceDataAsServiceResponse(DateTimeOffset? endDate, int limit = 288, CancellationToken cancellationToken = default);

    // <summary>
    /// Fetch the device's history between the start date and the end date, relative to the UTC timezone
    /// </summary>
    /// <param name="startDate">
    /// The start date where weather events will start being collected.
    /// </param>
    /// <param name="endDate">
    /// The end date where weather events will stop being collected.
    /// An end date of February 20th, 2021 will fetch February 19th, 00:05 - 23:55 UTC
    /// </param>
    /// <param name="sliceTheListFromTheBeginningOfTheList">This works in conjunction with the <see cref="limit"/> parameter.
    /// The API returns elements sliced from most recent to least recent per day.
    /// This parameter specifies that we should slice data from the beginning of the day (least recent) to most recent (end of the day)</param>
    /// <param name="limit">
    /// Returns the number of elements for each day, limited to a maximum of 288.
    /// If information is stored every 5 minutes, 288 events translates to one (1), 24 hour day.
    /// </param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Returns an <see cref="IAsyncEnumerable{IEnumerable}"/>.</returns>
    /// <exception cref="ArgumentException">When <see cref="endDate"/> is less than <see cref="startDate"/>.</exception>
    IAsyncEnumerable<IEnumerable<DeviceData>> FetchDeviceHistory(DateTimeOffset? startDate, DateTimeOffset? endDate, bool sliceTheListFromTheBeginningOfTheList = false, int limit = 288, CancellationToken token = default);

    /// <inheritdoc cref="FetchDeviceHistory(DateTimeOffset?, DateTimeOffset?, bool, int, CancellationToken)"/>
    /// <typeparam name="T"> A POCO to Deserialize JSON to.</typeparam>
    IAsyncEnumerable<IEnumerable<T>> FetchDeviceHistory<T>(DateTimeOffset? startDate, DateTimeOffset? endDate, bool sliceTheListFromTheBeginningOfTheList = false, int limit = 288, CancellationToken token = default)
        where T : class, new();

    /// <summary>
    /// Fetch the device's history between now and the number of days specified, relative to UTC
    /// </summary>
    /// <param name="numberOfDaysToGoBack">How many days we should go back in time to retrieve information from the weather station.</param>
    /// <param name="sliceTheListFromTheBeginningOfTheList">This works in conjunction with the <see cref="limit"/> parameter.
    /// The API returns elements sliced from most recent to least recent per day.
    /// This parameter specifies that we should slice data from the beginning of the day (least recent) to most recent (end of the day).</param>
    /// <param name="includeToday">Include Today's Weather Information in the return results.</param>
    /// <param name="limit">
    /// Returns the number of elements for each day, limited to a maximum of 288.
    /// If information is stored every 5 minutes, 288 events translates to one (1), 24 hour day.
    /// </param>
    /// <param name="token">Cancellation token.</param>
    /// <returns><see cref="IAsyncEnumerable{IEnumerable}"/>.</returns>
    /// <exception cref="ArgumentException">When the number of <see cref="numberOfDaysToGoBack"/>.Days is less than or equal to 0.</exception>
    IAsyncEnumerable<IEnumerable<DeviceData>> FetchDeviceHistory(TimeSpan numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, CancellationToken token = default);

    /// <inheritdoc cref="FetchDeviceHistory(TimeSpan, bool, bool, int, CancellationToken)"/>
    /// <typeparam name="T"> A POCO to Deserialize JSON too.</typeparam>
    IAsyncEnumerable<IEnumerable<T>> FetchDeviceHistory<T>(TimeSpan numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, CancellationToken token = default)
        where T : class, new();

    /// <inheritdoc cref="FetchDeviceHistory(TimeSpan, bool, bool, int, CancellationToken)" />
    IAsyncEnumerable<IEnumerable<DeviceData>> FetchDeviceHistory(int? numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, CancellationToken token = default);

    /// <inheritdoc cref="FetchDeviceHistory(TimeSpan, bool, bool, int, CancellationToken)" />
    /// <typeparam name="T"> A POCO to Deserialize JSON too.</typeparam>
    IAsyncEnumerable<IEnumerable<T>> FetchDeviceHistory<T>(int? numberOfDaysToGoBack, bool sliceTheListFromTheBeginningOfTheList = false, bool includeToday = true, int limit = 288, CancellationToken token = default)
        where T : class, new();

    /// <summary>
    /// Checks to see if there is data for the specified day; if <see cref="dateToCheck"/> is null, then the Ambient Weather API will return data for the current date
    /// </summary>
    /// <param name="dateToCheck">The date to check to see if we have data for.</param>
    /// <param name="cancellationToken">Cancellation Token. <see cref="CancellationToken" />.</param>
    /// <returns>Returns a bool: true - if data exists for that day; false - if it does not.</returns>
    /// <exception cref="ArgumentException">Throws ArgumentException if <see cref="_apiKey"/> or
    /// <see cref="ApplicationKey"/> are null, empty, or whitespace
    /// </exception>
    Task<bool> DoesDeviceDataExist(DateTimeOffset? dateToCheck, CancellationToken cancellationToken = default);
}
