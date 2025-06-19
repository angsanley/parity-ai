using ParityAI.Core.Interfaces;

namespace ParityAI.Infrastructure.OpenAI.Agents.ParityAgent.Tools;

public class ModuloParityTool : IParityTool
{
    public string Name => "ModuloParityTool";

    public ParityResult CheckParity(int number)
    {
        bool isEven = number % 2 == 0;
        return new ParityResult(isEven, $"{number} % 2 == {(isEven ? 0 : 1)} → {(isEven ? "EVEN" : "ODD")}");
    }
}
