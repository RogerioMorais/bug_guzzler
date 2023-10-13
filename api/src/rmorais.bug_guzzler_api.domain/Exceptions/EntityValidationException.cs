
namespace rmorais.bug_guzzler_api.domain.Exceptions;

public class EntityValidationException : Exception
{

    public EntityValidationException(
        string? message
    ) : base(message) {}
}