using MediatR;

namespace rmorais.bug_guzzler_api.application.UseCases.Requirement;

public class UpdateRequirementInput :IRequest<UpdateRequirementOutput>
{
    public UpdateRequirementInput(Guid id,String description){
        this.Id=id;
        this.Description=description;
    }
    public Guid Id { get; private set; }
    public String Description { get; private set; }

}
