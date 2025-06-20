using ParityAI.Core.Interfaces;

namespace ParityAI.Infrastructure.OpenAI.Agents.ParityAgent.Tools;

public class ModuloParityTool : IParityTool
{
    public string Name => "ModuloParityTool";
    public string Description => "Determines if a number is even or odd using the modulo operation.";

    public byte[] ParametersSchema => """
        {
            "type": "object",
            "properties": {
                "number": {
                    "type": "integer",
                    "description": "The number to check parity for."
                }
            },
            "required": [ "number" ]
        }
        """u8.ToArray();

    public ParityResult CheckParity(int number)
    {
        bool isEven = number % 2 == 0;
        return new ParityResult(isEven, $"{number} % 2 == {(isEven ? 0 : 1)} → {(isEven ? "EVEN" : "ODD")}");
    }
}
