using Ardalis.Result;
using Ardalis.SharedKernel;

namespace ParityAI.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
