using System.Text.Json.Serialization;

namespace AmbientDotNet.Models;

/// <summary>
///     Device parameters that am Ambient Weather device might send.<br />
///     Follows the spec found at <a href="https://github.com/ambient-weather/api-docs/wiki/Device-Data-Specs"></a>.
///     <para />
///     Note: Not all devices send all the parameters.
/// </summary>
public sealed record DeviceData
{
    /// <summary>
    ///     Wind direction reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("winddir")]
    public int? WindDirection { get; init; }

    /// <summary>
    ///     Wind speed in miles per hour, reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("windspeedmph")]
    public double? WindSpeedMph { get; init; }

    /// <summary>
    ///     Wind gust in miles per hour, reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("windgustmph")]
    public double? WindGustMph { get; init; }

    /// <summary>
    ///     The maximum windspeed from a wind gust for that day.
    /// </summary>
    [JsonPropertyName("maxdailygust")]
    public double? MaxDailyGust { get; init; }

    /// <summary>
    ///     The direction of the wind gust. 
    ///     <para/>
    ///     See <see cref="WindGustMph" />.
    /// </summary>
    [JsonPropertyName("windgustdir")]
    public int? WindGustDir { get; init; }

    /// <summary>
    ///     The average wind speed over a 2 minute period in miles per hour.
    /// </summary>
    [JsonPropertyName("windspdmph_avg2m")]
    public double? WindSpeedMph2MinuteAverage { get; init; }

    /// <summary>
    ///     The average wind direction over a 2 minute period.
    /// </summary>
    [JsonPropertyName("winddir_avg2m")]
    public int? WindDirection2MinuteAverage { get; init; }

    /// <summary>
    ///     The average wind speed over a 10 minute period in miles per hour.
    /// </summary>
    [JsonPropertyName("windspdmph_avg10m")]
    public double? WindSpeedMph10MinuteAverage { get; init; }

    /// <summary>
    ///     The average wind direction over a 10 minute period.
    /// </summary>
    [JsonPropertyName("winddir_avg10m")]
    public int? WindDirection10MinuteAverage { get; init; }

    /// <summary>
    ///     The outdoor humidity reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("humidity")]
    public int? OutdoorHumidity { get; init; }

    /// <summary>
    ///     Humidity Sensor 1.
    /// </summary>
    [JsonPropertyName("humidity1")]
    public int? HumiditySensor1 { get; init; }

    /// <summary>
    ///     Humidity Sensor 2.
    /// </summary>
    [JsonPropertyName("humidity2")]
    public int? HumiditySensor2 { get; init; }

    /// <summary>
    ///     Humidity Sensor 3.
    /// </summary>
    [JsonPropertyName("humidity3")]
    public int? HumiditySensor3 { get; init; }

    /// <summary>
    ///     Humidity Sensor 4.
    /// </summary>
    [JsonPropertyName("humidity4")]
    public int? HumiditySensor4 { get; init; }

    /// <summary>
    ///     Humidity Sensor 5.
    /// </summary>
    [JsonPropertyName("humidity5")]
    public int? HumiditySensor5 { get; init; }

    /// <summary>
    ///     Humidity Sensor 6.
    /// </summary>
    [JsonPropertyName("humidity6")]
    public int? HumiditySensor6 { get; init; }

    /// <summary>
    ///     Humidity Sensor 7.
    /// </summary>
    [JsonPropertyName("humidity7")]
    public int? HumiditySensor7 { get; init; }

    /// <summary>
    ///     Humidity Sensor 8.
    /// </summary>
    [JsonPropertyName("humidity8")]
    public int? HumiditySensor8 { get; init; }

    /// <summary>
    ///     Humidity Sensor 9.
    /// </summary>
    [JsonPropertyName("humidity9")]
    public int? HumiditySensor9 { get; init; }

    /// <summary>
    ///     Humidity Sensor 10.
    /// </summary>
    [JsonPropertyName("humidity10")]
    public int? HumiditySensor10 { get; init; }

    /// <summary>
    ///     Indoor Humidity reported by the Base Station.
    /// </summary>
    [JsonPropertyName("humidityin")]
    public int? IndoorHumidity { get; init; }

    /// <summary>
    ///     Outdoor temperature in Fahrenheit reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("tempf")]
    public double? OutdoorTemperatureFahrenheit { get; init; }

    /// <summary>
    ///     Temperature Sensor 1 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp1f")]
    public double? TemperatureSensor1 { get; init; }

    /// <summary>
    ///     Temperature Sensor 2 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp2f")]
    public double? TemperatureSensor2 { get; init; }

    /// <summary>
    ///     Temperature Sensor 3 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp3f")]
    public double? TemperatureSensor3 { get; init; }

    /// <summary>
    ///     Temperature Sensor 4 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp4f")]
    public double? TemperatureSensor4 { get; init; }

    /// <summary>
    ///     Temperature Sensor 5 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp5f")]
    public double? TemperatureSensor5 { get; init; }

    /// <summary>
    ///     Temperature Sensor 6 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp6f")]
    public double? TemperatureSensor6 { get; init; }

    /// <summary>
    ///     Temperature Sensor 7 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp7f")]
    public double? TemperatureSensor7 { get; init; }

    /// <summary>
    ///     Temperature Sensor 8 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp8f")]
    public double? TemperatureSensor8 { get; init; }

    /// <summary>
    ///     Temperature Sensor 9 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp9f")]
    public double? TemperatureSensor9 { get; init; }

    /// <summary>
    ///     Temperature Sensor 10 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("temp10f")]
    public double? TemperatureSensor10 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 1 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp1f")]
    public double? SoilTemperatureSensor1 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 2 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp2f")]
    public double? SoilTemperatureSensor2 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 3 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp3f")]
    public double? SoilTemperatureSensor3 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 4 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp4f")]
    public double? SoilTemperatureSensor4 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 5 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp5f")]
    public double? SoilTemperatureSensor5 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 6 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp6f")]
    public double? SoilTemperatureSensor6 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 7 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp7f")]
    public double? SoilTemperatureSensor7 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 8 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp8f")]
    public double? SoilTemperatureSensor8 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 9 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp9f")]
    public double? SoilTemperatureSensor9 { get; init; }

    /// <summary>
    ///     Soil Temperature Sensor 10 in Fahrenheit.
    /// </summary>
    [JsonPropertyName("soiltemp10f")]
    public double? SoilTemperatureSensor10 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 1.
    /// </summary>
    [JsonPropertyName("soilhum1")]
    public int? SoilHumiditySensor1 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 2.
    /// </summary>
    [JsonPropertyName("soilhum2")]
    public int? SoilHumiditySensor2 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 3.
    /// </summary>
    [JsonPropertyName("soilhum3")]
    public int? SoilHumiditySensor3 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 4.
    /// </summary>
    [JsonPropertyName("soilhum4")]
    public int? SoilHumiditySensor4 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 5.
    /// </summary>
    [JsonPropertyName("soilhum5")]
    public int? SoilHumiditySensor5 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 6.
    /// </summary>
    [JsonPropertyName("soilhum6")]
    public int? SoilHumiditySensor6 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 7.
    /// </summary>
    [JsonPropertyName("soilhum7")]
    public int? SoilHumiditySensor7 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 8.
    /// </summary>
    [JsonPropertyName("soilhum8")]
    public int? SoilHumiditySensor8 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 9.
    /// </summary>
    [JsonPropertyName("soilhum9")]
    public int? SoilHumiditySensor9 { get; init; }

    /// <summary>
    ///     Soil Humidity Sensor 10.
    /// </summary>
    [JsonPropertyName("soilhum10")]
    public int? SoilHumiditySensor10 { get; init; }

    /// <summary>
    ///     Leaf Wetness Sensor 1.
    /// </summary>
    [JsonPropertyName("leafwetness1")]
    public int? LeafWetness1 { get; set; }

    /// <summary>
    ///     Leaf Wetness Sensor 2.
    /// </summary>
    [JsonPropertyName("leafwetness2")]
    public int? LeafWetness2 { get; set; }

    /// <summary>
    ///     Leaf Wetness Sensor 3.
    /// </summary>
    [JsonPropertyName("leafwetness3")]
    public int? LeafWetness3 { get; set; }

    /// <summary>
    ///     Leaf Wetness Sensor 4.
    /// </summary>
    [JsonPropertyName("leafwetness4")]
    public int? LeafWetness4 { get; set; }

    /// <summary>
    ///     Leaf Wetness Sensor 5.
    /// </summary>
    [JsonPropertyName("leafwetness5")]
    public int? LeafWetness5 { get; set; }

    /// <summary>
    ///     Leaf Wetness Sensor 6.
    /// </summary>
    [JsonPropertyName("leafwetness6")]
    public int? LeafWetness6 { get; set; }

    /// <summary>
    ///     Leaf Wetness Sensor 7.
    /// </summary>
    [JsonPropertyName("leafwetness7")]
    public int? LeafWetness7 { get; set; }

    /// <summary>
    ///     Leaf Wetness Sensor 8.
    /// </summary>
    [JsonPropertyName("leafwetness8")]
    public int? LeafWetness8 { get; set; }

    /// <summary>
    ///     Soil Tension Sensor 1.
    /// </summary>
    [JsonPropertyName("soiltens1")]
    public double? SoilTension1 { get; set; }

    /// <summary>
    ///     Soil Tension Sensor 2.
    /// </summary>
    [JsonPropertyName("soiltens2")]
    public double? SoilTension2 { get; set; }

    /// <summary>
    ///     Soil Tension Sensor 3.
    /// </summary>
    [JsonPropertyName("soiltens3")]
    public double? SoilTension3 { get; set; }

    /// <summary>
    ///     Soil Tension Sensor 4.
    /// </summary>
    [JsonPropertyName("soiltens4")]
    public double? SoilTension4 { get; set; }

    /// <summary>
    ///     Growing DegreeDays (GDD) reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("gdd")]
    public int? GrowingDegreeDays { get; set; }

    /// <summary>
    ///     Evapotranspiration short (ETo), measured in inches/day, reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("etos")]
    public double? EvapotranspirationShort { get; set; }

    /// <summary>
    ///     Evapotranspiration tall (ETr), measured in inches/day, reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("etot")]
    public double? EvapotranspirationTall { get; set; }

    /// <summary>
    ///     Indoor Temperature in Fahrenheit reported by the Base Station.
    /// </summary>
    [JsonPropertyName("tempinf")]
    public double? IndoorTemperatureFahrenheit { get; init; }

    /// <summary>
    ///     Leak Detection Sensor 1. <br />
    ///     A value of 0 represents 'OK'. <br />
    ///     A value of 1 represents 'LEAK'. <br />
    ///     A value of 2 represents 'OFFLINEle'.
    /// </summary>
    [JsonPropertyName("leak1")]
    public int? LeakDetection1 { get; init; }

    /// <summary>
    ///     Leak Detection Sensor 2. <br />
    ///     A value of 0 represents 'OK'. <br />
    ///     A value of 1 represents 'LEAK'. <br />
    ///     A value of 2 represents 'OFFLINEle'.
    /// </summary>
    [JsonPropertyName("leak2")]
    public int? LeakDetection2 { get; init; }

    /// <summary>
    ///     Leak Detection Sensor 3. <br />
    ///     A value of 0 represents 'OK'. <br />
    ///     A value of 1 represents 'LEAK'. <br />
    ///     A value of 2 represents 'OFFLINEle'.
    /// </summary>
    [JsonPropertyName("leak3")]
    public int? LeakDetection3 { get; init; }

    /// <summary>
    ///     Leak Detection Sensor 4. <br />
    ///     A value of 0 represents 'OK'. <br />
    ///     A value of 1 represents 'LEAK'. <br />
    ///     A value of 2 represents 'OFFLINEle'.
    /// </summary>
    [JsonPropertyName("leak4")]
    public int? LeakDetection4 { get; init; }

    /// <summary>
    ///     Outdoor Battery indicator. <br />
    ///     A value of 1 represents an 'OK' battery level. <br />
    ///     A value of 0 represents a 'low' battery level.
    ///     <para />
    ///     For Meteobridge Users: the above value are flipped. See below. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'low' battery level.
    /// </summary>
    [JsonPropertyName("battout")]
    public int? OutdoorBatteryIndicator { get; init; }

    /// <summary>
    ///     Indoor Battery indicator. <br />
    ///     A value of 1 represents an 'OK' battery level. <br />
    ///     A value of 0 represents a 'Low' battery level.
    ///     <para />
    ///     For Meteobridge Users: the above value are flipped. See below. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'Low' battery level.
    /// </summary>
    [JsonPropertyName("battin")]
    public int? IndoorBatteryIndicator { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 1. <br />
    ///     A value of 1 represents an 'OK' battery level. <br />
    ///     A value of 0 represents a 'Low' battery level.
    ///     <para />
    ///     For Meteobridge Users: the above value are flipped. See below. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'Low' battery level.
    /// </summary>
    [JsonPropertyName("batt1")]
    public int? BatteryIndicator1 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 2. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt2")]
    public int? BatteryIndicator2 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 3. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt3")]
    public int? BatteryIndicator3 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 4. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt4")]
    public int? BatteryIndicator4 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 5. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt5")]
    public int? BatteryIndicator5 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 6. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt6")]
    public int? BatteryIndicator6 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 7. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt7")]
    public int? BatteryIndicator7 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 8. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt8")]
    public int? BatteryIndicator8 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 9. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt9")]
    public int? BatteryIndicator9 { get; init; }

    /// <summary>
    ///     A battery indicator for sensor 10. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt10")]
    public int? BatteryIndicator10 { get; init; }

    /// <summary>
    ///     A battery indicator for the PM 2.5 Air Quality Sensor. <br />
    ///     See <see cref="BatteryIndicator1" />.
    /// </summary>
    [JsonPropertyName("batt_25")]
    public int? PM25AirQualityBatteryIndicator { get; init; }

    /// <summary>
    ///     A battery indicator for the Lightning Sensor. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'Low' battery level.
    /// </summary>
    [JsonPropertyName("batt_lightning")]
    public int? LightningSensorBatteryIndicator { get; init; }

    /// <summary>
    ///     A battery indicator for Leak Detector 1. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'Low' battery level.
    /// </summary>
    [JsonPropertyName("battleak1")]
    public int? LeakDetectorBatteryIndicator1 { get; init; }

    /// <summary>
    ///     A battery indicator for Leak Detector 2. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'Low' battery level.
    /// </summary>
    [JsonPropertyName("battleak2")]
    public int? LeakDetectorBatteryIndicator2 { get; init; }

    /// <summary>
    ///     A battery indicator for Leak Detector 3. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'Low' battery level.
    /// </summary>
    [JsonPropertyName("battleak3")]
    public int? LeakDetectorBatteryIndicator3 { get; init; }

    /// <summary>
    ///     A battery indicator for Leak Detector 4. <br />
    ///     A value of 0 represents an 'OK' battery level. <br />
    ///     A value of 1 represents a 'Low' battery level.
    /// </summary>
    [JsonPropertyName("battleak4")]
    public int? LeakDetectorBatteryIndicator4 { get; init; }

    /// <summary>
    ///     A battery indicator for Soil Moisture Sensor 1. <br />
    ///     A value of 0 represents a 'Low' battery level. <br />
    ///     A value of 1 represents an 'OK' battery level.
    /// </summary>
    [JsonPropertyName("battsm1")]
    public int? SoilMoistureSensorBatteryIndicator1 { get; init; }

    /// <summary>
    ///     A battery indicator for Soil Moisture Sensor 2. <br />
    ///     A value of 0 represents a 'Low' battery level. <br />
    ///     A value of 1 represents an 'OK' battery level.
    /// </summary>
    [JsonPropertyName("battsm2")]
    public int? SoilMoistureSensorBatteryIndicator2 { get; init; }

    /// <summary>
    ///     A battery indicator for Soil Moisture Sensor 3. <br />
    ///     A value of 0 represents a 'Low' battery level. <br />
    ///     A value of 1 represents an 'OK' battery level.
    /// </summary>
    [JsonPropertyName("battsm3")]
    public int? SoilMoistureSensorBatteryIndicator3 { get; init; }

    /// <summary>
    ///     A battery indicator for Soil Moisture Sensor 4. <br />
    ///     A value of 0 represents a 'Low' battery level. <br />
    ///     A value of 1 represents an 'OK' battery level.
    /// </summary>
    [JsonPropertyName("battsm4")]
    public int? SoilMoistureSensorBatteryIndicator4 { get; init; }

    /// <summary>
    ///     A battery indicator for the CO2 Sensor.
    ///     <see cref="BatteryIndicator1" />
    /// </summary>
    [JsonPropertyName("batt_co2")]
    public int CO2SensorBatteryIndicator { get; init; }

    /// <summary>
    ///     A battery indicator for the Cellular Gateway.
    ///     <see cref="BatteryIndicator1" />
    /// </summary>
    [JsonPropertyName("batt_cellgateway")]
    public int CellularGatewayBatteryIndicator { get; init; }

    /// <summary>
    ///     Hourly Rainfall in Inches.
    /// </summary>
    [JsonPropertyName("hourlyrainin")]
    public double? HourlyRainfall { get; init; }

    /// <summary>
    ///     Daily Rainfall in Inches.
    /// </summary>
    [JsonPropertyName("dailyrainin")]
    public double? DailyRainfall { get; init; }

    /// <summary>
    ///     Previous 24 hour rainfall in inches.
    /// </summary>
    [JsonPropertyName("24hourrainin")]
    public double? Previous24HourRainfall { get; init; }

    /// <summary>
    ///     Weekly rainfall in inches.
    /// </summary>
    [JsonPropertyName("weeklyrainin")]
    public double? WeeklyRainfall { get; init; }

    /// <summary>
    ///     Monthly rainfall in inches.
    /// </summary>
    [JsonPropertyName("monthlyrainin")]
    public double? MonthlyRainfall { get; init; }

    /// <summary>
    ///     Yearly rainfall in inches.
    /// </summary>
    [JsonPropertyName("yearlyrainin")]
    public double? YearlyRainfall { get; init; }

    /// <summary>
    ///     Current event's rainfall in inches.
    /// </summary>
    [JsonPropertyName("eventrainin")]
    public double? EventRainfall { get; init; }

    /// <summary>
    ///     Total rainfall recorded by sensor in inches.
    /// </summary>
    [JsonPropertyName("totalrainin")]
    public double? TotalRainfall { get; init; }

    /// <summary>
    ///     Relative Barometric Pressure in inches of mercury (in-HG) reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("baromrelin")]
    public double? RelativeBarometricPressure { get; init; }

    /// <summary>
    ///     Absolute Barometric Pressure in inches of mercury (in-HG) reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("baromabsin")]
    public double? AbsoluteBarometricPressure { get; init; }

    /// <summary>
    ///     Ultra-violet radiation index reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("uv")]
    public int? UltravioletRadiationIndex { get; init; }

    /// <summary>
    ///     Solar Radiation measured in Watts Per Meter^2 (W/m^2) reported by the Outdoor Sensor Array.
    /// </summary>
    [JsonPropertyName("solarradiation")]
    public double? SolarRadiation { get; init; }

    /// <summary>
    ///     Carbon Dioxide measured in Parts Per Million.
    /// </summary>
    [JsonPropertyName("co2")]
    public double? CO2PartsPerMillion { get; init; }

    /// <summary>
    ///     Relay Sensor 1 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay1")]
    public int? Relay1 { get; init; }

    /// <summary>
    ///     Relay Sensor 2 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay2")]
    public int? Relay2 { get; init; }

    /// <summary>
    ///     Relay Sensor 3 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay3")]
    public int? Relay3 { get; init; }

    /// <summary>
    ///     Relay Sensor 4 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay4")]
    public int? Relay4 { get; init; }

    /// <summary>
    ///     Relay Sensor 5 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay5")]
    public int? Relay5 { get; init; }

    /// <summary>
    ///     Relay Sensor 6 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay6")]
    public int? Relay6 { get; init; }

    /// <summary>
    ///     Relay Sensor 7 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay7")]
    public int? Relay7 { get; init; }

    /// <summary>
    ///     Relay Sensor 8 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay8")]
    public int? Relay8 { get; init; }

    /// <summary>
    ///     Relay Sensor 9 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay9")]
    public int? Relay9 { get; init; }

    /// <summary>
    ///     Relay Sensor 10 - Value: 0 or 1.
    /// </summary>
    [JsonPropertyName("relay10")]
    public int? Relay10 { get; init; }

    /// <summary>
    ///     Latest Outdoor PM 2.5 Air Quality.
    ///     Measured in micrograms per cubic meter of air (µg/m^3).
    /// </summary>
    [JsonPropertyName("pm25")]
    public double? PM25OutdoorAirQuality { get; init; }

    /// <summary>
    ///     Outdoor PM 2.5 Air Quality, 24 hour average.
    ///     Measured in micrograms per cubic meter of air (µg/m^3).
    /// </summary>
    [JsonPropertyName("pm25_24h")]
    public double? PM25OutdoorAirQuality24HourAverage { get; init; }

    /// <summary>
    ///     Latest Indoor PM 2.5 Air Quality.
    ///     Measured in micrograms per cubic meter of air (µg/m^3).
    /// </summary>
    [JsonPropertyName("pm25_in")]
    public double? PM25IndoorAirQuality { get; init; }

    /// <summary>
    ///     Indoor PM 2.5 Air Quality, 24 hour average.
    ///     Measured in micrograms per cubic meter of air (µg/m^3).
    /// </summary>
    [JsonPropertyName("pm25_in_24h")]
    public double? PM25IndoorAirQuality24HourAverage { get; init; }

    //TODO:
    //pm25_in_aqin - PM2.5 Air Quality Sensor indoor, AQIN sensor, Float, µg/m^3
    //pm25_in_24h_aqin - PM2.5 Air Quality Sensor indoor, 24 hour running average, AQIN sensor, Float, µg/m^3
    //pm10_in_aqin - PM10 Air Quality Sensor, Float, µg/m^3
    //pm10_in_24h_aqin - PM10 Air Quality Sensor, 24 hour running average, Float, µg/m^3
    //co2_in_aqin - Indoor CO2 from AQIN, Int, ppm
    //co2_in_24h_aqin - Indoor CO2 from AQIN, 24 hour running average, Int, ppm
    //pm_in_temp_aqin - Indoor PM sensor temperature, Float, ºF
    //pm_in_humidity_aqin - Indoor PM sensor humidity, Int, %
    //aqi_pm25_aqin - AQI derived from PM25, AQIN sensor, Int
    //aqi_pm25_24h_aqin - AQI derived from PM25 Indoor, 24 hour running average, AQIN sensor, Int
    //aqi_pm10_aqin - AQI derived from PM10 Indoor, AQIN sensor, Int
    //aqi_pm10_24h_aqin - AQI derived from PM10 Indoor, 24 hour running average, AQIN sensor, Int
    //aqi_pm25_in - AQI derived from PM25 IN, Int
    //aqi_pm25_in_24h - AQI derived from PM25 IN, 24 hour running average, Int

    /// <summary>
    ///     The number of lightning strikes per day
    /// </summary>
    [JsonPropertyName("lightning_day")]
    public int? LightningStrikesPerDay { get; init; }

    /// <summary>
    ///     The number of lightning strikes within the hour
    /// </summary>
    [JsonPropertyName("lightning_hour")]
    public int? LightningStrikesPerHours { get; init; }

    /// <summary>
    ///     The time of the last lightning strike (in UTC)
    /// </summary>
    [JsonPropertyName("lightning_time")]
    public DateTimeOffset? LastLightningStrikeTime { get; init; }

    /// <summary>
    ///     Distance of the lightning strike from the sensor in miles
    /// </summary>
    [JsonPropertyName("lightning_distance")]
    public double? LightningStrikeDistance { get; init; }

    /// <summary>
    ///     IANA TimeZone.
    /// </summary>
    [JsonPropertyName("tz")]
    public string? IANATimeZone { get; init; }

    /// <summary>
    ///     Current Epoch (Unix) time from 1/1/1970 (measured in milliseconds, rounded down to nearest minute).
    /// </summary>
    [JsonPropertyName("dateutc")]
    public long? EpochMilliseconds { get; init; }

    /// <summary>
    ///     Last DateTime recorded where <see cref="HourlyRainfall"/> was > 0 inches.
    /// </summary>
    [JsonPropertyName("lastRain")]
    public DateTimeOffset LastRain { get; init; }

    /// <summary>
    ///     Dew Point Temperature in Fahrenheit.
    /// </summary>
    [JsonPropertyName("dewPoint")]
    public double? DewPointFahrenheit { get; init; }

    /// <summary>
    ///     Feels Like Temperature. <br/>
    ///     If temperature is less than 50ºF => Wind Chill. <br/>
    ///     If temperature is greater than 68ºF => Heat Index (calculated on server).
    /// </summary>
    [JsonPropertyName("feelsLike")]
    public double? OutdoorFeelsLikeTemperatureFahrenheit { get; init; }

    /// <summary>
    ///     DateTime version of <see cref="EpochMilliseconds"/>.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTimeOffset? UtcDate { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 1
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike1")]
    public double? FeelsLikeTemperatureFahrenheit1 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 2
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike2")]
    public double? FeelsLikeTemperatureFahrenheit2 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 3
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike3")]
    public double? FeelsLikeTemperatureFahrenheit3 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 4
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike4")]
    public double? FeelsLikeTemperatureFahrenheit4 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 5
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike5")]
    public double? FeelsLikeTemperatureFahrenheit5 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 6
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike6")]
    public double? FeelsLikeTemperatureFahrenheit6 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 7
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike7")]
    public double? FeelsLikeTemperatureFahrenheit7 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 8
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike8")]
    public double? FeelsLikeTemperatureFahrenheit8 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 9
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike9")]
    public double? FeelsLikeTemperatureFahrenheit9 { get; init; }

    /// <summary>
    ///     Feels Like Temperature Sensor 10
    ///     <see cref="OutdoorFeelsLikeTemperatureFahrenheit" />.
    /// </summary>
    [JsonPropertyName("feelsLike10")]
    public double? FeelsLikeTemperatureFahrenheit10 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 1
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint1")]
    public double? DewPointFahrenheit1 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 2
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint2")]
    public double? DewPointFahrenheit2 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 3
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint3")]
    public double? DewPointFahrenheit3 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 4
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint4")]
    public double? DewPointFahrenheit4 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 5
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint5")]
    public double? DewPointFahrenheit5 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 6
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint6")]
    public double? DewPointFahrenheit6 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 7
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint7")]
    public double? DewPointFahrenheit7 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 8
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint8")]
    public double? DewPointFahrenheit8 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 9
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint9")]
    public double? DewPointFahrenheit9 { get; init; }

    /// <summary>
    ///     Dew Point Temperature for Sensor 10
    ///     <see cref="DewPointFahrenheit" />.
    /// </summary>
    [JsonPropertyName("dewPoint10")]
    public double? DewPointFahrenheit10 { get; init; }

    /// <summary>
    /// Indoor Feels Like Temperature in Fahrenheit reported by the Base Station.
    /// </summary>
    [JsonPropertyName("feelsLikein")]
    public double? IndoorFeelsLikeTemperatureFahrenheit { get; init; }

    /// <summary>
    /// Indoor Dew Point Temperature in Fahrenheit reported by the Base Station.
    /// </summary>
    [JsonPropertyName("dewPointin")]
    public double? IndoorDewPointTemperatureFahrenheit { get; init; }



    // These properties are not documented on the Device Data Specs page of the official Ambient Weather documentation

    /// <summary>
    /// Unknown value? Probably something to do with Ambient Weathers Databases/Servers?
    /// </summary>`
    [JsonPropertyName("loc")]
    public string? Loc { get; init; }

    /// <summary>
    ///     Weather Station Mac Address. <br />
    ///     Always null when querying the REST API. <br />
    ///     Always populated when receiving events from the Websocket (Realtime) API.
    /// </summary>
    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; init; }
}
