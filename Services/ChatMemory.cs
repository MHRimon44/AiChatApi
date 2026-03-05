using System.Collections.Concurrent;

namespace AiChat.Api.Services;

// Very simple in-memory conversation store (replace with Redis/DB later)
public class ChatMemory
{
    private readonly ConcurrentDictionary<string, List<(string Role, string Content)>> _store = new();

    public List<(string Role, string Content)> Get(string conversationId)
        => _store.GetOrAdd(conversationId, _ => new List<(string, string)>());

    public void Add(string conversationId, string role, string content)
    {
        var list = Get(conversationId);
        lock (list)
        {
            list.Add((role, content));
            // keep last N messages
            if (list.Count > 20) list.RemoveRange(0, list.Count - 20);
        }
    }

    public string BuildPrompt(string conversationId, string systemPrompt)
    {
        var list = Get(conversationId);

        // Prompt format (simple + effective)
        // You can adjust to your style.
        var lines = new List<string>
        {
            $"SYSTEM: {systemPrompt}"
        };

        foreach (var (role, content) in list)
        {
            lines.Add($"{role.ToUpper()}: {content}");
        }

        lines.Add("ASSISTANT:");
        return string.Join("\n", lines);
    }
}