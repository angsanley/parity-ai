namespace ParityAI.Core.Interfaces;

public interface IOpenAIAgent
{
    Task<string> GetResponseAsync(string prompt, string model, int maxTokens, CancellationToken cancellationToken);
}