using FastEndpoints;
using MediatR;
using ParityAI.UseCases.Chats.SendMessages;

namespace ParityAI.Web.SendMessages;

public class SendMessages(
  IMediator mediator
) : Endpoint<SendMessagesRequest, string>
{
  public override void Configure()
  {
    Post("/send-messages");
    AllowAnonymous();
  }

  public override async Task HandleAsync(SendMessagesRequest request, CancellationToken cancellationToken)
  {
    var result = await mediator.Send(
        new SendMessagesQuery(request.Messages),
        cancellationToken
    );

    await SendOkAsync(result, cancellation: cancellationToken);
  }
}