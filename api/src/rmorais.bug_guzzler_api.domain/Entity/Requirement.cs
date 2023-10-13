using rmorais.bug_guzzler_api.domain.SeedWork;
using rmorais.bug_guzzler_api.domain.Validation;

namespace rmorais.bug_guzzler_api.domain.Entity;

public class Requirement : AggregateRoot
{
    public Requirement(string description, bool isactive=true)
        :base(){
        Description=description;
        IsActive=isactive;
        CreatedAt=DateTime.Now;
        Validate();
    }

    public string Description { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public void Activate(){
        IsActive=true;
         Validate();
    }

    public void Deactivate(){
        IsActive=false;
         Validate();
    }

    private void Validate()
    {
        DomainValidation.NotNull(Description, nameof(Description));
    }
}
