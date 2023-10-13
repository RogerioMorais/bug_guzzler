using rmorais.bug_guzzler.domain.Repository;
using Entity = rmorais.bug_guzzler.domain.Entity;
using rmorais.bug_guzzler.Application.Interfaces;

namespace rmorais.bug_guzzler.Application.UseCases.Requirement.CreateRequirement;

public class CreateRequirement: ICreateRequirement
{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly IRequirementRepositorory _RequirementRepositorory;

    public CreateRequirement(IRequirementRepositorory requirementRepositorory,IUnitOfWork unitOfWork)
    {
        _UnitOfWork=unitOfWork;
        _RequirementRepositorory=requirementRepositorory;

    }

    public async Task<CreateRequirementOutput>Handle(CreateRequirementInput input, CancellationToken cancellationToken)
    {
        var requirement = new Entity.Requirement(input.Description, input.IsActive);
        await _RequirementRepositorory.Insert(requirement,cancellationToken);
        await _UnitOfWork.Commit(cancellationToken);
        return new CreateRequirementOutput(requirement.Id,
                                            requirement.Description,
                                            requirement.IsActive,
                                            requirement.CreatedAt
                                            );
    }
}