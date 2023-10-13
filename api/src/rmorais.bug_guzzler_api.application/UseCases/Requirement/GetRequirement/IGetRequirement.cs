using MediatR;

namespace rmorais.bug_guzzler_api.application.UseCases.Requirement.GetRequirement;

public interface IGetRequirement : IRequestHandler<GetRequentInput,GetRequentOutput>
{

}
