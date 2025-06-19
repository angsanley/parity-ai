using ParityAI.Core.Interfaces;

namespace ParityAI.Core.Services;

public class BitwiseParityTool : IParityTool
{
    public string Name => "BitwiseParityTool";

    public ParityResult CheckParity(int number)
    {
        bool isEven = (number & 1) == 0;
        return new ParityResult(isEven, $"{number} & 1 == {(isEven ? 0 : 1)} → {(isEven ? "EVEN" : "ODD")}");
    }
}
