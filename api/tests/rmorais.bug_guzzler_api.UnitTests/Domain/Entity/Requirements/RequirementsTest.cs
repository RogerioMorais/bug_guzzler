using DomainEntity=rmorais.bug_guzzler_api.domain.Entity;
using FluentAssertions;
using rmorais.bug_guzzler_api.domain.Exceptions;
namespace rmorais.bug_guzzler_api.UnitTests.Domain.Entity.Requirements;

public class RequirementsTest
{
    [Fact(DisplayName=nameof(Instantiate))]
    [Trait("Domain","Requirements - Aggregates")]
    public void Instantiate()
    {
        var validData = new {
            Description="Description Requirements"
        };

        var requirement= new DomainEntity.Requirement(validData.Description);
        requirement.Should().NotBeNull();
        requirement.Description.Should().Be(validData.Description);
        requirement.Id.Should().NotBeEmpty();
        requirement.IsActive.Should().BeTrue();
    }


    [Theory(DisplayName=nameof(InstantiateWithIsActive))]
    [Trait("Domain","Requirements - Aggregates")]
    [InlineData(true)]
    [InlineData(false)]
    public void InstantiateWithIsActive(bool IsActive)
    {
        var validData = new {
            Description="Description Requirements"
        };

        var requirement= new DomainEntity.Requirement(validData.Description,IsActive);

        Assert.NotNull(requirement);
        Assert.Equal(validData.Description,requirement.Description);
        Assert.NotEqual(default(Guid),requirement.Id);
        Assert.NotEqual(default(DateTime),requirement.CreatedAt);
        Assert.Equal(IsActive,requirement.IsActive);
    }


    [Theory(DisplayName=nameof(DescricaoInvalida))]
    [Trait("Domain","Requirements - Validator")]
    [InlineData(null)]
    public void DescricaoInvalida(String description)
    {
   
        Action action =
            () => new DomainEntity.Requirement(description,true);

         action.Should()
            .Throw<EntityValidationException>()
            .WithMessage("Description should not be null");
    }

    [Fact(DisplayName=nameof(Activate))]
    [Trait("Domain","Requirements - Aggregates")]
    public void Activate()
    {
        var validData = new {
            Description="Description Requirements"
        };

        var requirement= new DomainEntity.Requirement(validData.Description,false);
        requirement.Activate();
        Assert.True(requirement.IsActive);
    }

    [Fact(DisplayName=nameof(Deactivate))]
    [Trait("Domain","Requirements - Aggregates")]
    public void Deactivate()
    {
        var validData = new {
            Description="Description Requirements"
        };

        var requirement= new DomainEntity.Requirement(validData.Description,true);
        requirement.Deactivate();
        Assert.False(requirement.IsActive);
    }

}