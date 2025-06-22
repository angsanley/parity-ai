using Ardalis.SharedKernel;

namespace ParityAI.UseCases.Chats.SendMessages;

public class SendMessagesQuery(
  List<string> messages
) : IQuery<string>
{
  public List<string> Messages { get; set; } = messages;
}