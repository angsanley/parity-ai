using Ardalis.Result;
using Ardalis.SharedKernel;

namespace ParityAI.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
