using Microsoft.EntityFrameworkCore;
using rmorais.bug_guzzler.domain.Entity;
using rmorais.bug_guzzler.Infra.Data.EF;
using rmorais.bug_guzzler.IntegrationTests.Base;

namespace rmorais.bug_guzzler.IntegrationTests.Infra.Data.EF.Repositories.RequirementRepository;

[CollectionDefinition(nameof(RequirementRepositoryTestFixture))]
public class RequirementRepositoryTestFixtureCollection
    :ICollectionFixture<RequirementRepositoryTestFixture>{}
public class RequirementRepositoryTestFixture:BaseFixture
{
    public Requirement GetExempleRequirement() => new(Faker.Finance.AccountName());

    public static BugGuzzlerCatalogDbContext CreateDbContext(){

        var dbContext = new BugGuzzlerCatalogDbContext(
            new DbContextOptionsBuilder<BugGuzzlerCatalogDbContext>()
            .UseInMemoryDatabase("Integration-test-db").Options);
    
        return dbContext;
    }
}
