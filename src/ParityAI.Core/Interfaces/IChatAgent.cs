namespace ParityAI.Core.Interfaces;

public interface IChatAgent
{
    IAsyncEnumerable<string> CompleteChatStreamingAsync(List<string> messages, string model, int maxTokens, CancellationToken cancellationToken);
}