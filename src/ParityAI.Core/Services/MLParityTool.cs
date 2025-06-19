using ParityAI.Core.Interfaces;

namespace ParityAI.Core.Services;

public class MLParityTool : IParityTool
{
    public string Name => "MLParityTool";

    public ParityResult CheckParity(int number)
    {
        // Pretend ML logic: just alternate for demo
        bool isEven = number % 2 == 0;
        return new ParityResult(isEven, $"Pretend ML says: {number} is {(isEven ? "EVEN" : "ODD")} (confidence: 99%)");
    }
}
