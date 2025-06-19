using ParityAI.Core.Interfaces;

namespace ParityAI.Core.Services;

public class ModuloParityTool : IParityTool
{
    public string Name => "ModuloParityTool";

    public ParityResult CheckParity(int number)
    {
        bool isEven = number % 2 == 0;
        return new ParityResult(isEven, $"{number} % 2 == {(isEven ? 0 : 1)} → {(isEven ? "EVEN" : "ODD")}");
    }
}
