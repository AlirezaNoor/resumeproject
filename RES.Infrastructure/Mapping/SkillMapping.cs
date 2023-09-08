using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RES.Domin.Skills;

namespace RES.Infrastructure.Mapping
{
    public class SkillMapping:IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
