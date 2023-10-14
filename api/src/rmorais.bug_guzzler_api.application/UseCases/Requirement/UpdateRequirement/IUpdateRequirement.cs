using MediatR;

namespace rmorais.bug_guzzler.application.UseCases.Requirement;

public interface IUpdateRequirement :IRequestHandler<UpdateRequirementInput,UpdateRequirementOutput>
{

}
