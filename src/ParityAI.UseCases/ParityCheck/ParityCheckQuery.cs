using Ardalis.SharedKernel;

namespace ParityAI.UseCases.ParityCheck;

public class ParityCheckQuery(string? message) : IQuery<ParityCheckResponse>
{
  public string? Message { get; set; } = message;
}