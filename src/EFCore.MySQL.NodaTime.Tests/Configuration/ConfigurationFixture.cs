using Microsoft.Extensions.Configuration;
using System;

namespace EntityFrameworkCore.MySQL.NodaTime.Tests.Configuration;

public class ConfigurationFixture
{
    private const string CONNECTION_STRING_KEY = "Default";

    private readonly IConfiguration _configuration;

    public ConfigurationFixture()
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
