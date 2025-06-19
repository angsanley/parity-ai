namespace ParityAI.Core.Parity;

public class ParityAgentDecision
{
  public ParityResult? Result { get; set; }
  public string Reasoning { get; set; } = string.Empty;
  public bool Escalated { get; set; }
}
