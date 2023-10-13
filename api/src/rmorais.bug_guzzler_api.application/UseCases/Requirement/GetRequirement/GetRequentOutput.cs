namespace rmorais.bug_guzzler_api.application.UseCases.Requirement.GetRequirement;

public class GetRequentOutput
{
    public GetRequentOutput(Guid id, string? description,bool isActive, DateTime createdAt){
        Id=id;
        Description=description!;
        IsActive=isActive;
        CreatedAt=createdAt;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
