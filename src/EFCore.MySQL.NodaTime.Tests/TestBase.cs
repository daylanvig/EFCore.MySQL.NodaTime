namespace EntityFrameworkCore.MySQL.NodaTime.Tests;

[Collection(nameof(MySQLTestCollection))]
public abstract class TestBase
{
    protected TestContext Context { get; }

    public TestBase(MySQLTestFixture fixture)
    {
        Context = fixture.CreateDefaultContext();
    }
}
