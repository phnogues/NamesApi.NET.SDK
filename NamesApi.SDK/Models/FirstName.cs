using System.Text.Json.Serialization;

namespace NamesApi.SDK.Models;

public class FirstName
{
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("score")]
    public int Score { get; set; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
}
