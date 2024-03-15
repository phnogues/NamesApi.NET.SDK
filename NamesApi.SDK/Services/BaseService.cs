using System.Text.Json;
using System.Text.Json.Serialization;

namespace NamesApi.SDK.Services;

public abstract class BaseService
{
    protected HttpClient HttpClient;
    protected JsonSerializerOptions JsonSerializerOptions;

    public BaseService(HttpClient httpClient)
    {
        HttpClient = httpClient;
        JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }

    protected async Task<TResult?> Get<TResult>(string requestUri)
    {
        var result = await HttpClient.GetAsync(requestUri);

        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            return default;

        HandleError(result);

        return await HandleResult<TResult>(result);
    }

    protected async Task<TResult?> GetList<TResult>(string requestUri)
    {
        var result = await HttpClient.GetAsync(requestUri);

        HandleError(result);

        return await HandleResult<TResult>(result);
    }

    private async Task<TResult?> HandleResult<TResult>(HttpResponseMessage result)
    {
        var json = await result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResult?>(json);
    }

    private void HandleError(HttpResponseMessage responseMessage)
    {
        if (responseMessage.IsSuccessStatusCode)
            return;

        switch (responseMessage.StatusCode)
        {
            case System.Net.HttpStatusCode.Unauthorized:
                throw new Exception("Unauthorized, please check your Api Token");

            case System.Net.HttpStatusCode.NotFound:
                throw new Exception("NotFound, Please check your parameters");

            case System.Net.HttpStatusCode.UnprocessableEntity:
                throw new Exception("UnprocessableEntity, Please check your content object, the item may already be used");

            default:
                throw new Exception($"An error occured: {responseMessage.StatusCode}");
        }
    }
}
