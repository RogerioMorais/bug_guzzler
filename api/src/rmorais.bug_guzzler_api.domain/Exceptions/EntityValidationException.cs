
namespace rmorais.bug_guzzler.domain.Exceptions;

public class EntityValidationException : Exception
{

    public EntityValidationException(
        string? message
    ) : base(message) {}
}