

using MediatR;
using rmorais.bug_guzzler_api.Application.Interfaces;
using rmorais.bug_guzzler_api.domain.Repository;

namespace rmorais.bug_guzzler_api.application.UseCases.Requirement;

public class DeleteRequirement : IDeleteRequirement
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IRequirementRepositorory _RequirementRepositorory;

    public DeleteRequirement(IRequirementRepositorory requirementRepositorory,IUnitOfWork unitOfWork)
    {
        _UnitOfWork=unitOfWork;
        _RequirementRepositorory=requirementRepositorory;
    }

    public async Task Handle(DeleteRequirementInput request, CancellationToken cancellationToken)
    {
        var requirement= await _RequirementRepositorory.Get(request.Id,cancellationToken);
        await _RequirementRepositorory.Delete(requirement,cancellationToken);
        await _UnitOfWork.Commit(cancellationToken);
    }
}