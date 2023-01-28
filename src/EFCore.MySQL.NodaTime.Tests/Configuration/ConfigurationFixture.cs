using Microsoft.Extensions.Configuration;
using System;

namespace EntityFrameworkCore.MySQL.NodaTime.Tests.Configuration;

/// <summary>
/// Singleton provider for accessing application configuration values
/// </summary>
public class ConfigurationFixture
{
    private static readonly Lazy<ConfigurationFixture> _instance = new(() => new ConfigurationFixture());
    public static ConfigurationFixture Instance => _instance.Value;

    #region Keys
    private const string CONNECTION_STRING_KEY = "Default";
    #endregion
    private readonly IConfiguration _configuration;

    private ConfigurationFixture()
    {
        _configuration = CreateConfiguration();
    }

    private static IConfiguration CreateConfiguration()
    {
        return new ConfigurationBuilder()
                        .AddJsonFile("Configuration/appsettings.json")
                        .Build();
    }


    public string ConnectionString => _configuration.GetConnectionString(CONNECTION_STRING_KEY) ?? throw new Exception("Connection string not found in configuration");
}
