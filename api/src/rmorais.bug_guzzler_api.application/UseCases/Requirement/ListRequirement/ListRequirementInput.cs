using MediatR;
using rmorais.bug_guzzler.application.Common;
using rmorais.bug_guzzler.domain.SeedWork.SearchableRepository;

namespace rmorais.bug_guzzler.application.UseCases.Requirement;

public class ListRequirementInput : PaginatedListInput, IRequest<ListRequirementOutput>
{
    public ListRequirementInput(int page =1, int perPage=15, string search="", string sort = "", SearchOrder dir =SearchOrder.Asc) : base(page, perPage, search, sort, dir)
    {
    }
}
