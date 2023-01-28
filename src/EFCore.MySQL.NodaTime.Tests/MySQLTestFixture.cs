using EntityFrameworkCore.MySQL.NodaTime.Tests.Configuration;

namespace EntityFrameworkCore.MySQL.NodaTime.Tests;

// FUTURE: Potentially extend this to be able to be able to create multiple different schemas if performance becomes an issue, ref "CreateContext"  https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/blob/master/test/EFCore.MySql.Tests/MySqlTestFixtureBase.cs

public sealed class MySQLTestFixture
{
    private readonly DbContextOptions _dbContextOptions;

    public MySQLTestFixture()
    {
        var serverVersion = ServerVersion.AutoDetect(ConfigurationFixture.Instance.ConnectionString);
        _dbContextOptions = new DbContextOptionsBuilder()
                                .UseMySql(ConfigurationFixture.Instance.ConnectionString, serverVersion)
                                .Options;
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        var context = CreateDefaultContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public TestContext CreateDefaultContext()
    {
        return new TestContext(_dbContextOptions);
    }
}

[CollectionDefinition(nameof(MySQLTestCollection))]
public class MySQLTestCollection : ICollectionFixture<MySQLTestFixture>
{

}
