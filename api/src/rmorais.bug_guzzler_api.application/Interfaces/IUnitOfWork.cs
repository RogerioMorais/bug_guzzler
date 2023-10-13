namespace rmorais.bug_guzzler.Application.Interfaces;

public interface IUnitOfWork 
{
    public Task Commit(CancellationToken cancellationToken);
}