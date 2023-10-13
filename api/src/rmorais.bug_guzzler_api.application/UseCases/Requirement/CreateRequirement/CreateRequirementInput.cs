using MediatR;

namespace rmorais.bug_guzzler_api.Application.UseCases.Requirement.CreateRequirement;

public class CreateRequirementInput : IRequest<CreateRequirementOutput>
{
    public CreateRequirementInput(string? description=null, bool isactive=true){
        Description=description!;
        IsActive=isactive;
    }

    public string Description { get; set; }
    public bool IsActive {get;set;}
}