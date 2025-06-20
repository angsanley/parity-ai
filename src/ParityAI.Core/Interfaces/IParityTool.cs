namespace ParityAI.Core.Interfaces;

public interface IParityTool
{
    /// <summary>
    /// The unique identifier for this tool.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// A brief description of what this tool does.
    /// This should be concise and clear, explaining the purpose of the tool.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Schema for the parameters expected by this tool.
    /// This should be a JSON schema that describes the input parameters.
    /// It is used to validate the input before calling the tool.
    /// </summary>
    byte[] ParametersSchema { get; }
    
    ParityResult CheckParity(int number);
}

public record ParityResult(bool IsEven, string Reason);
