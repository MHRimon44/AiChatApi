namespace AiChat.Api.Models;

public class OllamaGenerateRequest
{
    public string Model { get; set; } = "llama3";
    public string Prompt { get; set; } = "";
    public bool Stream { get; set; } = false;
}