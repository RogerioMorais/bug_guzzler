using MediatR;

namespace rmorais.bug_guzzler_api.application.UseCases.Requirement;

public class DeleteRequirementInput : IRequest
{
    public DeleteRequirementInput(Guid id)=>Id=id;
    public Guid Id {get;private set;}
}
