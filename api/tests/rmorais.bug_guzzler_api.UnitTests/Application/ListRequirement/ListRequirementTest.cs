using Moq;
using FluentAssertions;
using useCase=rmorais.bug_guzzler.application.UseCases.Requirement;
using rmorais.bug_guzzler.domain.Entity;
using rmorais.bug_guzzler.domain.Repository;
using rmorais.bug_guzzler.domain.SeedWork.SearchableRepository;
using rmorais.bug_guzzler.application.UseCases.Requirement;

namespace rmorais.bug_guzzler.UnitTests.ListRequirement;

public class ListRequirementTest
{
    [Fact(DisplayName = nameof(List))]
    [Trait("Application","ListRequirement - Use Cases")]
    public async Task List(){
         
         var listOfRequirement=getRequirementStub(70);
         var repositoryMoke = new Mock<IRequirementRepositorory>();
         var input = new useCase.ListRequirementInput(
            page:2,
            perPage:15,
            search:"seacrch-example",
            sort:"name",
            dir: SearchOrder.Asc
         );

        var outputRepositorySearch=new SearchOutput<Requirement>(
            currentPage:input.Page,
            perPage:input.PerPage,
            items:listOfRequirement,
            total:70
            );
            
        repositoryMoke.Setup(x=>x.Search(
            It.Is<SearchInput>(
                searchInput=>searchInput.Page==input.Page
                && searchInput.PerPage==input.PerPage
                && searchInput.Search==input.Search
                && searchInput.OrderBy==input.Sort
                && searchInput.Order==input.Dir
            ),It.IsAny<CancellationToken>())
            ).ReturnsAsync(outputRepositorySearch);

        var useCase=new useCase.ListRequirement(repositoryMoke.Object);

        var output = await useCase.Handle(input,CancellationToken.None);

        output.Should().NotBeNull();
        output.Page.Should().Be(outputRepositorySearch.CurrentPage);
        output.PerPage.Should().Be(outputRepositorySearch.PerPage);
        output.Total.Should().Be(outputRepositorySearch.Total);
        output.Items.Should().HaveCount(outputRepositorySearch.Items.Count);
        ((List<LitRequirementItemOutput>) output.Items).ForEach(output=>{
            var repositoryItem=outputRepositorySearch.Items.FirstOrDefault(x=>x.Id ==output.Id);
            output.Should().NotBeNull();
            output.Description.Should().Be(repositoryItem!.Description);
            output.IsActive.Should().Be(repositoryItem!.IsActive);
            
        });

         repositoryMoke.Verify(x=>x.Search(
            It.Is<SearchInput>(
                searchInput=>searchInput.Page==input.Page
                && searchInput.PerPage==input.PerPage
                && searchInput.Search==input.Search
                && searchInput.OrderBy==input.Sort
                && searchInput.Order==input.Dir
            ),
            It.IsAny<CancellationToken>()
         ),Times.Once);

    }

    private static IReadOnlyList<Requirement> getRequirementStub(int amount){
        
        var list=new List<Requirement>();
        for (int i = 0; i < amount; i++)
        {
            list.Add(new Requirement("Descrição "+amount,true));
        }
        return list;
    }
}
