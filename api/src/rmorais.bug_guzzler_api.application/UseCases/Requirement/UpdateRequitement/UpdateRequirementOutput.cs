namespace rmorais.bug_guzzler_api.application.UseCases.Requirement;

public class UpdateRequirementOutput
{

    public UpdateRequirementOutput(Guid id, string? description,bool isActive, DateTime createdAt){
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
