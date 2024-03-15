namespace NamesApi.SDK.Tests;

public class FirstNameTests : BaseTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task GetFirstName_ShouldReturn_Pierre()
    {
        string firstName = "pierre";

        var result = await namesApiClient.FirstNames.GetByName(firstName);

        Assert.IsTrue(result.Value == firstName);
    }
}