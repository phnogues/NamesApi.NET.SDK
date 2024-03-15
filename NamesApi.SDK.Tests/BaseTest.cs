using Microsoft.Extensions.Configuration;

namespace NamesApi.SDK.Tests;

public class BaseTest
{
    public NamesApiClient namesApiClient;

    public BaseTest()
    {
        var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

        namesApiClient = new NamesApiClient(config["TokenAPI"]);
    }
}
