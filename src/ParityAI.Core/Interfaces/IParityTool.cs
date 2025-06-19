namespace ParityAI.Core.Interfaces;

public interface IParityTool
{
    string Name { get; }
    ParityResult CheckParity(int number);
}

public record ParityResult(bool IsEven, string Reason);
