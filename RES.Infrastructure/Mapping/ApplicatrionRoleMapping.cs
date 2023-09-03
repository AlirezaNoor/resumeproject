using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RES.Domin.Identity;

namespace RES.Infrastructure.Mapping
{
    public class ApplicatrionRoleMapping:IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
             
        }
    }
}
