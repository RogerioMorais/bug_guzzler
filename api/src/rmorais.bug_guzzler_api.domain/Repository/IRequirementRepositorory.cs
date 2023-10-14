using rmorais.bug_guzzler.domain.Entity;
using rmorais.bug_guzzler.domain.SeedWork;
using rmorais.bug_guzzler.domain.SeedWork.SearchableRepository;

namespace rmorais.bug_guzzler.domain.Repository;

public interface IRequirementRepositorory:IGenericRepository<Requirement>,ISearchableRepository<Requirement>
{ 

}