using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using rmorais.bug_guzzler.domain.Entity;
using rmorais.bug_guzzler.Infra.Data.EF.Configurations;

namespace rmorais.bug_guzzler.Infra.Data.EF;

public class BugGuzzlerCatalogDbContext : DbContext
{
    
    public DbSet<Requirement> Requirements => Set<Requirement>();  

    public BugGuzzlerCatalogDbContext(
        DbContextOptions<BugGuzzlerCatalogDbContext> options
        ): base(options){}

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new RequirementConfiguration());
        }

}
