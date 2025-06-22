namespace ParityAI.Core.Interfaces;

public interface IChatAgent
{
    Task<string> GetResponseAsync(string prompt, string model, int maxTokens, CancellationToken cancellationToken);
}