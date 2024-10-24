using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace StackUp.Application.Services;

public class ChatService
{
    #region Dependencies

    private readonly string _apiKey;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<ChatService> _logger;
    private readonly string _model;

    public ChatService(IConfiguration configuration, IHttpClientFactory httpClientFactory, ILogger<ChatService> logger)
    {
        _apiKey = configuration["HuggingFace:ApiKey"];
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _model = configuration["HuggingFace:Model"] ?? "EleutherAI/gpt-neo-2.7B";

        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new ArgumentException("HuggingFace API key is not configured.");
        }
    }
    #endregion

    public async Task<string> GetResponseAsync(string prompt)
    {
        var client = _httpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

        var requestBody = new
        {
            inputs = prompt,
            parameters = new
            {
                max_length = 200,
                temperature = 0.7,
                top_p = 0.9
            }
        };

        var jsonContent = JsonConvert.SerializeObject(requestBody);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync($"https://api-inference.huggingface.co/models/{_model}", content);

            var responseBody = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("HuggingFace API Response: {ResponseBody}", responseBody);

            if (response.IsSuccessStatusCode)
            {
                if (responseBody.StartsWith("["))
                {
                    var jsonArray = JArray.Parse(responseBody);
                    if (jsonArray.Count > 0)
                    {
                        var firstItem = jsonArray[0];
                        if (firstItem["generated_text"] != null)
                        {
                            return firstItem["generated_text"].ToString();
                        }
                        else if (firstItem.Type == JTokenType.String)
                        {
                            return firstItem.ToString();
                        }
                    }
                }
                else if (responseBody.StartsWith("{"))
                {
                    var jsonObject = JObject.Parse(responseBody);
                    if (jsonObject["generated_text"] != null)
                    {
                        return jsonObject["generated_text"].ToString();
                    }
                }

                return "Received an unexpected response from the AI service.";
            }
            else
            {
                _logger.LogError("HuggingFace API Error {StatusCode}: {ErrorBody}", response.StatusCode, responseBody);
                return "An error occurred while communicating with the AI service.";
            }
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, "HTTP request to HuggingFace API failed.");
            return "Error communicating with the AI service.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred in ChatService.");
            return "An unexpected error occurred.";
        }
    }
}
public class HuggingFaceResponseItem
{
    [JsonProperty("generated_text")]
    public string GeneratedText { get; set; }
}