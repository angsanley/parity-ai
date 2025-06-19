using ParityAI.Core.Interfaces;

namespace ParityAI.Infrastructure.OpenAI.Agents.ParityAgent.Tools;

public class BitwiseParityTool : IParityTool
{
    public string Name => "BitwiseParityTool";
    public string Description => "Determines if a number is even or odd using bitwise operations.";

    public ParityResult CheckParity(int number)
    {
        bool isEven = (number & 1) == 0;
        return new ParityResult(isEven, $"{number} & 1 == {(isEven ? 0 : 1)} → {(isEven ? "EVEN" : "ODD")}");
    }
}
