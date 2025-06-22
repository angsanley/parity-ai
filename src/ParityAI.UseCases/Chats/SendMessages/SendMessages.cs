using System.Text;
using Ardalis.SharedKernel;
using ParityAI.Core.Interfaces;

namespace ParityAI.UseCases.Chats.SendMessages;

public class SendMessage(
  IChatAgent chatAgent
) : IQueryHandler<SendMessagesQuery, string>
{
  public async Task<string> Handle(SendMessagesQuery request, CancellationToken cancellationToken)
  {
    var messages = request.Messages;

    IAsyncEnumerable<string> responseStream = chatAgent.CompleteChatStreamingAsync(
      messages: messages,
      model: "gpt-4o-mini",
      maxTokens: 1000,
      cancellationToken: cancellationToken
    );

    StringBuilder responseBuilder = new StringBuilder();

    await foreach (var response in responseStream)
    {
      Console.WriteLine($"Consumed: {response}");
      responseBuilder.Append(response);
    }

    string responseString = responseBuilder.ToString();

    return responseString;
  }
}