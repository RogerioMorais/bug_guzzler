
using rmorais.bug_guzzler.domain.Repository;

namespace rmorais.bug_guzzler.application.UseCases.Requirement;

public class ListRequirement : IListRequirement
{
       private readonly IRequirementRepositorory _RequirementRepositorory;

    public ListRequirement(IRequirementRepositorory requirementRepositorory)
    {
        _RequirementRepositorory=requirementRepositorory;
    }

    public async Task<ListRequirementOutput> Handle(ListRequirementInput request, CancellationToken cancellationToken)
    {
            var searchOutput= await _RequirementRepositorory.Search(new (request.Page,
                                                                  request.PerPage,
                                                                  request.Search,
                                                                  request.Sort,
                                                                  request.Dir),
                                                                  cancellationToken);
            var output =new ListRequirementOutput(
                searchOutput.CurrentPage,
                searchOutput.PerPage,
                searchOutput.Total,
                searchOutput.Items
                    .Select(x=> new LitRequirementItemOutput(x.Id,
                                                         x.Description,
                                                         x.IsActive,
                                                         x.CreatedAt)).ToList()
                                                         );
            return output;
    }
}
