using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using rmorais.bug_guzzler.Infra.Data.EF;
using Repository=rmorais.bug_guzzler.Infra.Data.EF.Repositories;

namespace rmorais.bug_guzzler.IntegrationTests.Infra.Data.EF.Repositories.RequirementRepository;

[Collection(nameof(RequirementRepositoryTestFixture))]
public class RequirementRepositoryTest
{
    private readonly RequirementRepositoryTestFixture _fixture;

    public RequirementRepositoryTest(RequirementRepositoryTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName =nameof(Insert))]
    [Trait("Integration/Infra.Data","RequirementRepository - Repository")]
    public async Task Insert(){
        
        BugGuzzlerCatalogDbContext dbContext = RequirementRepositoryTestFixture.CreateDbContext();
        
        var exempleRequirement =_fixture.GetExempleRequirement();
        var RequirementRepository = new Repository.RequirementRepository(dbContext);

        await RequirementRepository.Insert(exempleRequirement,CancellationToken.None);
        await dbContext.SaveChangesAsync(CancellationToken.None);
        var dbRequirement = await dbContext.Requirements.FindAsync(exempleRequirement.Id);
        
        dbRequirement.Should().NotBeNull();
        dbRequirement!.Id.Should().Be(exempleRequirement.Id);
        dbRequirement.Description.Should().Be(exempleRequirement.Description);
        dbRequirement.CreatedAt.Should().Be(exempleRequirement.CreatedAt);
    }

}
