using Bogus;
using FluentAssertions;
using rmorais.bug_guzzler_api.domain.Exceptions;
using rmorais.bug_guzzler_api.domain.Validation;

namespace rmorais.bug_guzzler_api.UnitTests.Domain.Validation;

public class DomainValidationTest
{   
    private Faker Faker {get;set;} = new Faker();

    [Fact(DisplayName=nameof(NotNullOk))]
    [Trait("Domain","DomainValidation - Validation")]
    public void NotNullOk(){
        var value=Faker.Commerce.ProductName();
        Action action=
        ()=>DomainValidation.NotNull(value,"FieldName");

        action.Should().NotThrow();
    }   

    
    [Fact(DisplayName=nameof(NotNullOk))]
    [Trait("Domain","DomainValidation - Validation")]
    public void NotNullThrowWhenNull(){
        string? value = null;
        Action action=
        ()=>DomainValidation.NotNull(value!,"FieldName");

        action.Should()
        .Throw<EntityValidationException>()
        .WithMessage("FieldName should not be null");
    }  
}