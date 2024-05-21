using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    internal class SkillConfigurations : IEntityTypeConfiguration<Skill>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Skill> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
