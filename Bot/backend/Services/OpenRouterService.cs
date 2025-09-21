using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace JarbasBot.Services
{
    public class OpenRouterService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenRouterService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;

            _apiKey = Environment.GetEnvironmentVariable("OPENROUTER_API_KEY")
                ?? throw new InvalidOperationException("Chave da API OpenRouter não foi encontrada.");

            _httpClient.Timeout = TimeSpan.FromSeconds(30);

            // Headers fixos do OpenRouter
            if (!_httpClient.DefaultRequestHeaders.Contains("HTTP-Referer"))
                _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost:8080");

            if (!_httpClient.DefaultRequestHeaders.Contains("X-Title"))
                _httpClient.DefaultRequestHeaders.Add("X-Title", "JarbasBot");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> AskJarbas(string pergunta)
        {
            if (string.IsNullOrWhiteSpace(pergunta))
                return "Ô meu, manda uma pergunta direito aí!";

            var requestBody = new
            {
                model = "mistralai/mistral-small-3.2-24b-instruct:free",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = $"Você é o Jarbas, um assistente informal e carismático que fala com gírias e bom humor. Sempre responde como um amigo experiente e direto.\n\n{pergunta}"
                    }
                },
                max_tokens = 1000,
                temperature = 0.7
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await _httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                using var json = JsonDocument.Parse(responseString);

                if (json.RootElement.TryGetProperty("choices", out var choices) &&
                    choices.GetArrayLength() > 0 &&
                    choices[0].TryGetProperty("message", out var message) &&
                    message.TryGetProperty("content", out var contentProp))
                {
                    return contentProp.GetString()?.Trim() ?? "Poxa, não consegui entender a resposta da API...";
                }

                return "Eita, a resposta da API veio estranha, véi!";
            }
            catch (HttpRequestException ex)
            {
                return $"Deu zica na conexão: {ex.Message} (Status: {(int?)ex.StatusCode ?? 0})";
            }
            catch (JsonException)
            {
                return "Opa, o formato da resposta tá zoado!";
            }
            catch (Exception ex)
            {
                return $"Eita, algo deu ruim: {ex.Message}";
            }
        }
    }
}