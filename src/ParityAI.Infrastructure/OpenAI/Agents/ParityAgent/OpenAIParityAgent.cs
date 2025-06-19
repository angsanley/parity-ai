using System.ClientModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenAI;
using OpenAI.Chat;
using ParityAI.Core.Interfaces;

namespace ParityAI.Infrastructure.OpenAI.Agents.ParityAgent;

public class OpenAIParityAgent : IOpenAIAgent
{
    private readonly IServiceProvider _serviceProvider;
    private Dictionary<string, (IParityTool, ChatTool)>? _tools;
    private ILogger<OpenAIParityAgent> _logger;

    private readonly string _systemPrompt = "";

    public OpenAIParityAgent(
        IServiceProvider serviceProvider,
        ILogger<OpenAIParityAgent> logger
    )
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        PopulateTools();
    }

    public async Task<string> GetResponseAsync(string prompt, string model, int maxTokens, CancellationToken cancellationToken)
    {
        ChatClient client = new ChatClient(model, "api-key");

        ChatCompletionOptions options = new();
        _tools?.Values.ToList().ForEach(tool =>
        {
            options.Tools.Add(tool.Item2);
        });

        List<ChatMessage> messages =
        [
            new UserChatMessage("tell me which tools are available"),
        ];

        bool requiresAction = false;

        do
        {
            requiresAction = false;
            ChatCompletion completion = await client.CompleteChatAsync(messages, options, cancellationToken);

            switch (completion.FinishReason)
            {
                case ChatFinishReason.Stop:
                    {
                        // Add the assistant message to the conversation history.
                        messages.Add(new AssistantChatMessage(completion));
                        
                        _logger.LogDebug("Received response: {Response}", completion.Content);
                        break;
                    }

                case ChatFinishReason.ToolCalls:
                    {
                        // First, add the assistant message with tool calls to the conversation history.
                        messages.Add(new AssistantChatMessage(completion));

                        // Then, process each tool call.
                        foreach (ChatToolCall toolCall in completion.ToolCalls)
                        {
                            // Check if the tool exists in the dictionary.
                            if (_tools is null || !_tools.TryGetValue(toolCall.FunctionName, out var
                                    toolInfo))
                            {
                                throw new NotImplementedException($"Tool '{toolCall.FunctionName}' not found.");
                            }

                            // Execute the tool and get the result.
                            var tool = toolInfo.Item1;

                            using JsonDocument argumentsJson = JsonDocument.Parse(toolCall.FunctionArguments);
                            bool hasNumber = argumentsJson.RootElement.TryGetProperty("number", out JsonElement numberElement);

                            if (!hasNumber || !numberElement.TryGetInt32(out int number))
                            {
                                throw new ArgumentException("Invalid or missing 'number' argument in tool call.");
                            }

                            var toolResult = tool.CheckParity(
                                number
                            );

                            // Create a new message with the tool result.
                            messages.Add(
                                new ToolChatMessage(
                                    toolCall.Id,
                                    toolResult.ToString()
                                )
                            );

                            _logger.LogDebug("Tool call result: {ToolResult}", toolResult);
                        }

                        break;
                    }

                case ChatFinishReason.Length:
                    throw new NotImplementedException("Incomplete model output due to MaxTokens parameter or token limit exceeded.");

                case ChatFinishReason.ContentFilter:
                    throw new NotImplementedException("Omitted content due to a content filter flag.");

                case ChatFinishReason.FunctionCall:
                    throw new NotImplementedException("Deprecated in favor of tool calls.");

                default:
                    throw new NotImplementedException(completion.FinishReason.ToString());
            }
        } while (requiresAction is true);

        // Return the final response from the assistant.
        return messages?.LastOrDefault()?.Content.ToString() ?? string.Empty;
    }

    private void PopulateTools()
    {
        if (_tools is not null) return;

        _tools = _serviceProvider.GetServices<IParityTool>()
            .ToDictionary(
                tool => tool.Name,
                tool =>
                {
                    JsonSerializerOptions options = JsonSerializerOptions.Default;
                    JsonNode schema = options.GetJsonSchemaAsNode(typeof(IParityTool));

                    var chatTool = ChatTool.CreateFunctionTool(
                        functionName: tool.Name,
                        functionDescription: tool.Description,
                        functionParameters: BinaryData.FromString(schema.ToString())
                    );
                    return (tool, chatTool);
                }
            );
    }
}