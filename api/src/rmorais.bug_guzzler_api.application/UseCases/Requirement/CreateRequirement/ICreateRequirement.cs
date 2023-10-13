using MediatR;

namespace rmorais.bug_guzzler.Application.UseCases.Requirement.CreateRequirement;
public interface ICreateRequirement : IRequestHandler<CreateRequirementInput,CreateRequirementOutput>
{
}