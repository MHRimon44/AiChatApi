using System.Net.Http.Json;
using AiChat.Api.Models;

namespace AiChat.Api.Services;

public class OllamaClient
{
    private readonly HttpClient _http;
    private readonly IConfiguration _config;

    public OllamaClient(HttpClient http, IConfiguration config)
    {
        _http = http;
        _config = config;
    }

    public async Task<string> GenerateAsync(string prompt)
    {
        var model = _config["OLLAMA_MODEL"] ?? "llama3";

        // IMPORTANT:
        // If backend runs on a different machine than Ollama, update baseUrl.
        var baseUrl = _config["OLLAMA_BASE_URL"] ?? "http://localhost:11434";

        var req = new OllamaGenerateRequest
        {
            Model = model,
            Prompt = prompt,
            Stream = false
        };

        var res = await _http.PostAsJsonAsync($"{baseUrl}/api/generate", req);
        res.EnsureSuccessStatusCode();

        // Ollama returns JSON like { "response": "...", ... }
        var json = await res.Content.ReadFromJsonAsync<OllamaGenerateResponse>();
        return json?.Response ?? "";
    }
}