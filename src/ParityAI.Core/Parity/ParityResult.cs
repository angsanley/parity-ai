namespace ParityAI.Core.Parity;

  public class ParityResult
  {
      public int Number { get; set; }
      public bool IsEven { get; set; }
      public ParityToolType ToolUsed { get; set; }
      public string Reason { get; set; } = string.Empty;
      public double Confidence { get; set; }
  }
