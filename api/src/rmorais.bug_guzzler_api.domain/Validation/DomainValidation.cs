using rmorais.bug_guzzler.domain.Exceptions;

namespace rmorais.bug_guzzler.domain.Validation;

public class DomainValidation
{
    public static void NotNull(object target,string fieldName)
    {
        if(target is null){
            throw new EntityValidationException($"{fieldName} should not be null");
        }
    }
}