using OpenAI;
using ParityAI.Core.Interfaces;

namespace ParityAI.Infrastructure.OpenAI;

public class OpenAIService(OpenAIClient client) : IOpenAIService
{
    private readonly OpenAIClient _client = client;

    public Task<string> GetResponseAsync(string prompt, string model, int maxTokens, CancellationToken cancellationToken)
    {
        throw new NotImplementedException("This method is not implemented yet.");
    }
}