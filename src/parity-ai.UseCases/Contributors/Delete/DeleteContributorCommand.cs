using Ardalis.Result;
using Ardalis.SharedKernel;

namespace parity_ai.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
