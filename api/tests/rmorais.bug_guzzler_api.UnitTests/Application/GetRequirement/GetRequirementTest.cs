using FluentAssertions;
using Moq;
using rmorais.bug_guzzler_api.application.Exceptions;
using UserCase=rmorais.bug_guzzler_api.application.UseCases.Requirement;
using rmorais.bug_guzzler_api.domain.Entity;
using rmorais.bug_guzzler_api.domain.Repository;

namespace rmorais.bug_guzzler_api.UnitTests.GetRequirement;

public class GetRequirementTest
{
    
    [Fact(DisplayName=nameof(GetRequirement))]
    [Trait("Application","GetRequirement - Use Cases")]
    public async Task GetRequirement()
    {
            var repositorioMock = new Mock <IRequirementRepositorory>();
            var requirement=new Requirement("Test Requirement");
            repositorioMock.Setup(x => x.Get(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()
                )).ReturnsAsync(requirement);
            
            var input = new UserCase.GetRequentInput(requirement.Id);
            var useCase=new UserCase.GetRequirement(repositorioMock.Object);
            var output = await useCase.Handle(input,CancellationToken.None);

                repositorioMock.Verify(x => x.Get(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()
                    ),
                    Times.Once);

        output.Should().NotBeNull();
        output.Id.Should().Be(requirement.Id);
        output.Description.Should().Be(requirement.Description);
            
    }

   
    [Fact(DisplayName=nameof(GetRequirementNotFound))]
    [Trait("Application","GetRequirement - Use Cases")]
    public async Task GetRequirementNotFound()
    {
            var repositorioMock = new Mock <IRequirementRepositorory>();
            var requirement=new Requirement("Test Requirement");
            repositorioMock.Setup(x => x.Get(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()
                )).ThrowsAsync(new NotFoundException("Requirement not Found"));
            
            var input = new UserCase.GetRequentInput(requirement.Id);
            var useCase=new UserCase.GetRequirement(repositorioMock.Object);
            var task =async()=> await useCase.Handle(input,CancellationToken.None);

            await task.Should().ThrowAsync<NotFoundException>();

                repositorioMock.Verify(x => x.Get(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()
                    ),
                    Times.Once);
            
    }
}
