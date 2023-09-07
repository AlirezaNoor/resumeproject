using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RES.Domin.Whatido;

namespace RES.Infrastructure.Mapping
{
    public class IdoMapping:IEntityTypeConfiguration<Ido>
    {
        public void Configure(EntityTypeBuilder<Ido> builder)
        {
            builder.ToTable("IDo");
            builder.HasKey(x => x.Id);
        }
    }
}
