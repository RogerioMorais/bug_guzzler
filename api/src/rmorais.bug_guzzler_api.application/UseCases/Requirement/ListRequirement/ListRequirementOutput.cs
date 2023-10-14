using MediatR;
using rmorais.bug_guzzler.application.Common;
using rmorais.bug_guzzler.domain.SeedWork.SearchableRepository;

namespace rmorais.bug_guzzler.application.UseCases.Requirement;

public class ListRequirementOutput : PaginatedListOutput<LitRequirementItemOutput>,IRequest<ListRequirementOutput>
{
    public ListRequirementOutput(int page, int perPage, int total, IReadOnlyList<LitRequirementItemOutput> items) : base(page, perPage, total, items)
    {
    }
}
