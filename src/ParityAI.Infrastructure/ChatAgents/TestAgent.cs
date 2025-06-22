using System.Runtime.CompilerServices;
using ParityAI.Core.Interfaces;

namespace ParityAI.Infrastructure.ChatAgents;

public class TestAgent : IChatAgent
{
  public async IAsyncEnumerable<string> CompleteChatStreamingAsync(
    List<string> messages,
    string model,
    int maxTokens,
    [EnumeratorCancellation] CancellationToken cancellationToken
  )
  {
    for (int i = 0; i < 5; i++)
    {
      if (cancellationToken.IsCancellationRequested) yield break;

      await Task.Delay(500, cancellationToken); // simulate async I/O or work
      Console.WriteLine($"Generated: {i}");
      yield return $"{i}";
    }
  }
}