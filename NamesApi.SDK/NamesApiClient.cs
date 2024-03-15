using NamesApi.SDK.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NamesApi.SDK;

public class NamesApiClient
{
    const string API_URL = "https://names-api.com/api/";

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    private FirstNameService? _firstNames;


    public NamesApiClient(string token)
    {
        _httpClient = new HttpClient();

        if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            _httpClient.DefaultRequestHeaders.Remove("Authorization");

        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        _httpClient.BaseAddress = new Uri(API_URL);
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    public FirstNameService FirstNames => _firstNames ??= new FirstNameService(_httpClient);
}
