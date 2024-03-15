using NamesApi.SDK.Models;

namespace NamesApi.SDK.Services;

public class FirstNameService : BaseService
{

    public FirstNameService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<FirstName?> GetByName(string firstName)
    {
        var result = await Get<FirstName>($"firstnames/{firstName}");

        return result;
    }
}