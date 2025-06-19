using Ardalis.Result;
using Ardalis.SharedKernel;

namespace parity_ai.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
