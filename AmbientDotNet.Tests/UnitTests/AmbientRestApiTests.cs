using AmbientDotNet.Infrastructure;
using AmbientDotNet.Models;
using Microsoft.Extensions.Options;
using Moq;

namespace AmbientDotNet.Tests.UnitTests;

public class AmbientRestApiTests
{
    private const string SampleApplicationKey = "application-key";
    private const string SampleMacAddress = "2F:29:A3:78:A1:B5";
    private const string SampleApiKey = "super-secret-api-key-1";

    [Fact]
    public async Task FetchDeviceDataAsync_Success()
    {
        var mockAmbientService = new Mock<Api.IAmbientService>();

        IEnumerable<DeviceData> expectedDeviceList = new List<DeviceData>
                { new DeviceData { MacAddress = SampleMacAddress } };

        mockAmbientService.Setup(
            x => x.Fetch<DeviceData>(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
            )
        ).ReturnsAsync(
            ServiceResponse.Ok(expectedDeviceList)
        ).Verifiable();

        using var ambientRestApi = new AmbientRestApi(
            options: GetAmbientConfig(SampleApplicationKey, SampleMacAddress, SampleApiKey),
            service: mockAmbientService.Object
        );

        var results = await ambientRestApi.FetchDeviceDataAsync(
            System.DateTimeOffset.UtcNow,
            limit: 100,
            cancellationToken: CancellationToken.None
        );

        Assert.NotNull(results);
        Assert.NotEmpty(results);

        mockAmbientService.Verify();

        Assert.Equal(expectedDeviceList, results);
    }

    [Fact]
    public async Task FetchDeviceDataAsync_Success_ZeroLimit()
    {
        var mockAmbientService = new Mock<Api.IAmbientService>();

        using var ambientRestApi = new AmbientRestApi(
            options: GetAmbientConfig(SampleApplicationKey, SampleMacAddress, SampleApiKey),
            service: mockAmbientService.Object
        );

        var results = await ambientRestApi.FetchDeviceDataAsync(DateTimeOffset.UtcNow, 0, CancellationToken.None);

        Assert.NotNull(results);
        Assert.Empty(results);

        mockAmbientService.Verify();
    }

    [Fact]
    public async Task FetchDeviceDataAsync_ServiceResponse_Failure()
    {
        var mockAmbientService = new Mock<Api.IAmbientService>();

        mockAmbientService.Setup(
            x => x.Fetch<DeviceData>(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
            )
        ).ReturnsAsync(
            ServiceResponse.Fail<IEnumerable<DeviceData>>("Error occurred!")
        ).Verifiable();

        using var ambientRestApi = new AmbientRestApi(
            options: GetAmbientConfig(SampleApplicationKey, SampleMacAddress, SampleApiKey),
            service: mockAmbientService.Object
        );

        var results = await ambientRestApi.FetchDeviceDataAsync(DateTimeOffset.UtcNow, 100, CancellationToken.None);

        Assert.NotNull(results);
        Assert.Empty(results);

        mockAmbientService.Verify();
    }

    [Theory]
    [InlineData("", SampleMacAddress, SampleApiKey)]
    [InlineData(SampleApplicationKey, "", SampleApiKey)]
    [InlineData(SampleApplicationKey, SampleMacAddress, "")]
    public void FetchDeviceDataAsync_ArgumentValidation(string applicationKey, string macAddress, string apiKey)
    {
        var mockAmbientService = new Mock<Api.IAmbientService>();

        using var ambientRestApi = new AmbientRestApi(
            options: GetAmbientConfig(applicationKey, macAddress, apiKey),
            service: mockAmbientService.Object
        );

        var exception = Assert.ThrowsAsync<ArgumentException>(
            async () => await ambientRestApi.FetchDeviceDataAsync(DateTimeOffset.UtcNow, 100, CancellationToken.None)
        );

        //Assert.Contains(
        //    exception.ParamName,
        //    new List<string>
        //    {
        //        nameof(ambientRestApi.ApplicationKey),
        //        nameof(ambientRestApi.ApiKey),
        //        nameof(ambientRestApi.MacAddress)
        //    }
        //);
    }

    private static IOptions<AmbientConfig> GetAmbientConfig(string applicationKey, string macAddress, params string[] apiKeys)
    {
        return Options.Create(
            new AmbientConfig
            {
                ApplicationKey = applicationKey,
                MacAddress = macAddress,
                ApiKeys = [.. apiKeys],
            }
        );
    }
}
