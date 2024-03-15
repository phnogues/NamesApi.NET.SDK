using Microsoft.Extensions.DependencyInjection;

namespace NamesApi.SDK;

public static class DependencyInjectionRegistration
{
    public static void AddPhraseStrings(this IServiceCollection services, string tokenApi)
    {
        services.AddScoped(s => new NamesApiClient(tokenApi));
    }
}
