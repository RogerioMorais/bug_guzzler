using Moq;
using FluentAssertions;
using rmorais.bug_guzzler.Application.Interfaces;
using rmorais.bug_guzzler.domain.Repository;
using useCase=rmorais.bug_guzzler.application.UseCases.Requirement;
using rmorais.bug_guzzler.application.Exceptions;

namespace rmorais.bug_guzzler.UnitTests.UpdateRequirement;

public class UpdateRequirementTest
{
    [Fact(DisplayName=nameof(UpdateRequirement))]
    [Trait("Application","UpdateRequirement - Use Case")]
    public async Task UpdateRequirement(){

        var repositoryMock = new Mock<IRequirementRepositorory>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var requirement=new domain.Entity.Requirement("Test Requirement");
        repositoryMock.Setup(x=> x.Get(requirement.Id,
                                        It.IsAny<CancellationToken>()))
                                        .ReturnsAsync(requirement);

        var input = new useCase.UpdateRequirementInput(requirement.Id,"Description Requirements");

        var useCase = new useCase.UpdateRequirement(repositoryMock.Object,
                                            unitOfWorkMock.Object);
        useCase.UpdateRequirementOutput output = await useCase.Handle(input,CancellationToken.None);

        output.Should().NotBeNull();
        output.Id.Should().Be(input.Id);
        output.Description.Should().Be(input.Description);
        
        repositoryMock.Verify(x => x.Get(requirement.Id,
                                          It.IsAny<CancellationToken>()
                                          ),Times.Once);

        repositoryMock.Verify(x => x.Update(requirement,
                                          It.IsAny<CancellationToken>()
                                          ),Times.Once);
        unitOfWorkMock.Verify(x =>x.Commit(It.IsAny<CancellationToken>()));

    }

    [Fact(DisplayName=nameof(UpdateRequirementNotFound))]
    [Trait("Application","UpdateRequirement - Use Case")]
    public async Task UpdateRequirementNotFound(){

        var repositoryMock = new Mock<IRequirementRepositorory>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var requirement=new domain.Entity.Requirement("Test Requirement");
        repositoryMock.Setup(x=> x.Get(requirement.Id,
                                        It.IsAny<CancellationToken>())
                            ).ThrowsAsync(new NotFoundException($"Requirement not found"));

        var input = new useCase.UpdateRequirementInput(requirement.Id,"Description Requirements");

        var useCase = new useCase.UpdateRequirement(repositoryMock.Object,
                                            unitOfWorkMock.Object);

        var task =async()=>await useCase.Handle(input,CancellationToken.None);

        await task.Should().ThrowAsync<NotFoundException>();

        repositoryMock.Verify(x => x.Get(requirement.Id,
                                          It.IsAny<CancellationToken>()
                                          ),Times.Once);

    }
}