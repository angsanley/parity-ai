namespace ParityAI.Core.Interfaces;

public interface IOpenAIService
{
    Task<string> GetResponseAsync(string prompt, string model, int maxTokens, CancellationToken cancellationToken);
}