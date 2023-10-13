using MediatR;

namespace rmorais.bug_guzzler_api.Application.UseCases.Requirement.CreateRequirement;
public interface ICreateRequirement : IRequestHandler<CreateRequirementInput,CreateRequirementOutput>
{
   // public Task<CreateRequirementOutput>Handle(CreateRequirementInput input, CancellationToken cancellationToken);
}