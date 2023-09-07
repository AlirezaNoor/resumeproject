using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RES.Domin.Aboutsme;

namespace RES.Infrastructure.Mapping
{
    public class aboutmemapping:IEntityTypeConfiguration<aboutme>
    {
        public void Configure(EntityTypeBuilder<aboutme> builder)
        {
            builder.ToTable("about");
            builder.HasKey(x => x.Id);
        }
    }
}
