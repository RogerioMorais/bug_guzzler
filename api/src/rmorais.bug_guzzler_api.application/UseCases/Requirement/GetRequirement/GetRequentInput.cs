using MediatR;

namespace rmorais.bug_guzzler_api.application.UseCases.Requirement;

public class GetRequentInput : IRequest<GetRequentOutput>
{
    public GetRequentInput(Guid id)=>Id=id;
    public Guid Id {get;private set;}
}
