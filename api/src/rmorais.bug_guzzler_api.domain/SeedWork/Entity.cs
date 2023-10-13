namespace rmorais.bug_guzzler.domain.SeedWork;
public abstract class Entity 
{
    protected Entity()=>Id=Guid.NewGuid();
    
    public Guid Id { get; protected set; }
}