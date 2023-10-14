using MediatR;
using rmorais.bug_guzzler.application.Common;
using rmorais.bug_guzzler.domain.SeedWork.SearchableRepository;

namespace rmorais.bug_guzzler.application.UseCases.Requirement;

public class ListRequirementInput : PaginatedListInput, IRequest<ListRequirementOutput>
{
    public ListRequirementInput(int page, int perPage, string search, string sort, SearchOrder dir) : base(page, perPage, search, sort, dir)
    {
    }
}
