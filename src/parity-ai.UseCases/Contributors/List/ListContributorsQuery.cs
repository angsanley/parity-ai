using Ardalis.Result;
using Ardalis.SharedKernel;

namespace parity_ai.UseCases.Contributors.List;

public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
