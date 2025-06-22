namespace ParityAI.Web.SendMessages;

public class SendMessagesRequest
{
  public required List<string> Messages { get; set; } = new();
}