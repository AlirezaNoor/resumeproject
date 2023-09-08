using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RES.Domin.Blog;

namespace RES.Infrastructure.Mapping
{
    public class Blogmapping:IEntityTypeConfiguration<BlogAgg>
    {
        public void Configure(EntityTypeBuilder<BlogAgg> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
