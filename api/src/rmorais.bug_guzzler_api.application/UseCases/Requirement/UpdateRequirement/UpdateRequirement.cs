
using rmorais.bug_guzzler.Application.Interfaces;
using rmorais.bug_guzzler.domain.Repository;

namespace rmorais.bug_guzzler.application.UseCases.Requirement;

public class UpdateRequirement : IUpdateRequirement
{   private readonly IUnitOfWork _unitOfWork;
    private readonly IRequirementRepositorory _requirementRepositorory;

    public UpdateRequirement(IRequirementRepositorory requirementRepositorory, IUnitOfWork unitOfWork){
        this._requirementRepositorory=requirementRepositorory;
        this._unitOfWork=unitOfWork;
    }
    public async Task<UpdateRequirementOutput> Handle(UpdateRequirementInput request, CancellationToken cancellationToken)
    {
        var requirement= await this._requirementRepositorory.Get(request.Id,cancellationToken);
        requirement.Update(request.Description);
        await this._requirementRepositorory.Update(requirement,cancellationToken);   
        await this._unitOfWork.Commit(cancellationToken);

        return new UpdateRequirementOutput(requirement.Id,
                                            requirement.Description,
                                            requirement.IsActive,
                                            requirement.CreatedAt
                                            );         

    }
}
