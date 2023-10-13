using MediatR;
using rmorais.bug_guzzler_api.domain.Repository;

namespace rmorais.bug_guzzler_api.application.UseCases.Requirement.GetRequirement;

public class GetRequirement : IGetRequirement
{
     private readonly IRequirementRepositorory _RequirementRepositorory;

     public GetRequirement(IRequirementRepositorory requirementRepositorory)
    {

        _RequirementRepositorory=requirementRepositorory;

    }

 public async Task<GetRequentOutput>Handle(GetRequentInput input, CancellationToken cancellationToken)
    {

       var requirement= await _RequirementRepositorory.Get(input.Id,cancellationToken);
       
        return new GetRequentOutput(requirement.Id,
                                   requirement.Description,
                                   requirement.IsActive,
                                   requirement.CreatedAt
                                    );
    }

}
