using Microsoft.Extensions.Configuration;

namespace Client.Services;

public abstract class BaseService
{
    protected string ConnectionString { get; set; }
    public BaseService()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = config.GetConnectionString("pgsql")!;

    }
}
