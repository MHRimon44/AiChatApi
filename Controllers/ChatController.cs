using AiChat.Api.Models;
using AiChat.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiChat.Api.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private static readonly ChatMemory Memory = new();
    private readonly OllamaClient _ollama;

    public ChatController(IHttpClientFactory httpFactory, IConfiguration config)
    {
        _ollama = new OllamaClient(httpFactory.CreateClient(), config);
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponse>> Chat([FromBody] ChatRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Message))
            return BadRequest("Message is required.");

        var conversationId = string.IsNullOrWhiteSpace(req.ConversationId) ? "default" : req.ConversationId;

        var systemPrompt =
            "You are a helpful AI assistant. Keep answers clear and practical. " +
            "If user asks for code, provide runnable examples.";

        // Add user message to memory
        Memory.Add(conversationId, "user", req.Message);

        // Build prompt with history
        var prompt = Memory.BuildPrompt(conversationId, systemPrompt);

        // Call LLM
        var reply = await _ollama.GenerateAsync(prompt);

        // Add assistant reply to memory
        Memory.Add(conversationId, "assistant", reply);

        return Ok(new ChatResponse
        {
            ConversationId = conversationId,
            Reply = reply.Trim()
        });
    }
}