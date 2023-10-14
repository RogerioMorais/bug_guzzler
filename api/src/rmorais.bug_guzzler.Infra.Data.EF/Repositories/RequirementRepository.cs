using Microsoft.EntityFrameworkCore;
using rmorais.bug_guzzler.domain.Entity;
using rmorais.bug_guzzler.domain.Repository;
using rmorais.bug_guzzler.domain.SeedWork.SearchableRepository;

namespace rmorais.bug_guzzler.Infra.Data.EF.Repositories;

public class RequirementRepository : IRequirementRepositorory
{
    private BugGuzzlerCatalogDbContext _context;
    private DbSet<Requirement> _requirement =>_context.Set<Requirement>();

    public RequirementRepository(BugGuzzlerCatalogDbContext context)=>_context=context;

    public Task Delete(Requirement aggregate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Requirement> Get(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(Requirement aggregate, CancellationToken cancellationToken)
        => await _context.AddAsync(aggregate,cancellationToken);
    

    public Task<SearchOutput<Requirement>> Search(SearchInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(Requirement aggregate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}