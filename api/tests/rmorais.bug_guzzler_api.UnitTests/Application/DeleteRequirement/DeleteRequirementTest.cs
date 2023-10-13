using FluentAssertions;
using Moq;
using useCase=rmorais.bug_guzzler_api.application.UseCases.Requirement;
using rmorais.bug_guzzler_api.Application.Interfaces;
using rmorais.bug_guzzler_api.domain.Entity;
using rmorais.bug_guzzler_api.domain.Repository;

namespace rmorais.bug_guzzler_api.UnitTests.DeleteRequirement;

public class DeleteRequirementTest
{
    [Fact(DisplayName=nameof(DeleteCategory))]
    [Trait("Application","DeleteCategory - Use Cases")]
    public async Task DeleteCategory(){

        var repositorioMock = new Mock<IRequirementRepositorory>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var requirement=new Requirement("Test Requirement");
        repositorioMock.Setup(x=> x.Get(requirement.Id,
                                        It.IsAny<CancellationToken>()))
                                        .ReturnsAsync(requirement);

        var input = new useCase.DeleteRequirementInput(requirement.Id);
        var useCase = new useCase.DeleteRequirement(repositorioMock.Object,
                                            unitOfWorkMock.Object);
        await useCase.Handle(input,CancellationToken.None);

        repositorioMock.Verify(x => x.Get(requirement.Id,
                                          It.IsAny<CancellationToken>()
                                          ),Times.Once);

        repositorioMock.Verify(x => x.Delete(requirement,
                                          It.IsAny<CancellationToken>()
                                          ),Times.Once);   
         unitOfWorkMock.Verify(x =>x.Commit(It.IsAny<CancellationToken>()));                                          
    }

}