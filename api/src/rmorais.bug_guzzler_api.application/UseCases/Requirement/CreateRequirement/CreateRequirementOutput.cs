namespace rmorais.bug_guzzler.Application.UseCases.Requirement.CreateRequirement;

public class CreateRequirementOutput
{
    public CreateRequirementOutput(Guid id, string? description,bool isActive, DateTime createdAt){
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