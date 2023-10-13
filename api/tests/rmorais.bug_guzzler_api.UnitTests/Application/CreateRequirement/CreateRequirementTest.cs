using Moq;
using rmorais.bug_guzzler.domain.Entity;
using rmorais.bug_guzzler.domain.Repository;
using rmorais.bug_guzzler.Application.Interfaces;
using UseCases=rmorais.bug_guzzler.Application.UseCases.Requirement.CreateRequirement;
using FluentAssertions;

namespace rmorais.bug_guzzler_api.UnitTests.Application.CreateRequirement;

public class CreateRequirementTest {

    [Fact(DisplayName=nameof(CreateRequirement))]
    [Trait("Application","CreateRequirement - Use Cases")]
    public async void CreateRequirement()
    {
        var repositorioMock = new Mock<IRequirementRepositorory>();
        var unitOfWorkMock = new Mock<IUnitOfWork>();

        var useCase=new UseCases.CreateRequirement(repositorioMock.Object,
                                         unitOfWorkMock.Object);
        var input=new UseCases.CreateRequirementInput("Description Requirements");

        var output = await useCase.Handle(input,CancellationToken.None);

        repositorioMock.Verify(repository=>repository.Insert(It.IsAny<Requirement>(),
                                                             It.IsAny<CancellationToken>()
                                ),
                                Times.Once);
    
        unitOfWorkMock.Verify(uow=>uow.Commit(It.IsAny<CancellationToken>()),
                                Times.Once);

        output.Should().NotBeNull();
        (output.Id != Guid.Empty).Should().BeTrue();
        output.Description.Should().Be(input.Description);

    }
}