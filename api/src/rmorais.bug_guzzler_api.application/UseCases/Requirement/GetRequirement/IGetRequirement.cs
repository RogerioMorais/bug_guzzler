using MediatR;

namespace rmorais.bug_guzzler.application.UseCases.Requirement;

public interface IGetRequirement : IRequestHandler<GetRequentInput,GetRequentOutput>
{

}
