namespace rmorais.bug_guzzler_api.Application.Interfaces;

public interface IUnitOfWork 
{
    public Task Commit(CancellationToken cancellationToken);
}