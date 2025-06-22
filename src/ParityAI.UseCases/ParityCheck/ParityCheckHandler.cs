// using Ardalis.SharedKernel;
// using ParityAI.Core.Interfaces;

// namespace ParityAI.UseCases.ParityCheck;

// public class ParityCheckHandler(
//   IChatAgent openAIAgent
// ) : IQueryHandler<ParityCheckQuery, ParityCheckResponse>
// {
//   public async Task<ParityCheckResponse> Handle(ParityCheckQuery request, CancellationToken cancellationToken)
//   {
//     var response = await openAIAgent.GetResponseAsync(
//       prompt: "",
//       model: "gpt-4o-mini",
//       maxTokens: 1000,
//       cancellationToken: cancellationToken
//     );

//     return new ParityCheckResponse()
//     {
//       Message = response
//     };
//   }
// }
