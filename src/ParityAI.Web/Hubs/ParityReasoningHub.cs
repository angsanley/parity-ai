using Microsoft.AspNetCore.SignalR;
using ParityAI.Core.Parity;

namespace ParityAI.Web.Hubs;

public class ParityReasoningHub : Hub
{
  public async Task StartReasoning(ParityCheckRequest request)
  {
    // Call Mediator, stream back reasoning
    // Caller should listen to "ReasoningStep" or "FinalResult"
  }
}
