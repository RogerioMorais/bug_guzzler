using MediatR;

namespace rmorais.bug_guzzler_api.application.UseCases.Requirement;

public interface IGetRequirement : IRequestHandler<GetRequentInput,GetRequentOutput>
{

}
