using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rmorais.bug_guzzler.domain.Entity;

namespace rmorais.bug_guzzler.Infra.Data.EF.Configurations;

internal class RequirementConfiguration
    : IEntityTypeConfiguration<Requirement>
{
    public void Configure(EntityTypeBuilder<Requirement> builder)
    {
        builder.HasKey(requirement => requirement.Id);
        builder.Property(requirement => requirement.Description).HasMaxLength(10_000);
    }
}
