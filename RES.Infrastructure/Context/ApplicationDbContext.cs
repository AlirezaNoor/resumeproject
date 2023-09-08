using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RES.Domin.Aboutsme;
using RES.Domin.Blog;
using RES.Domin.Identity;
using RES.Domin.PersonalInformation;
using RES.Domin.Skills;
using RES.Domin.Whatido;
using RES.Infrastructure.Mapping;

namespace RES.Infrastructure.Context
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Personal> Personals { get; set; }
        public DbSet<aboutme> aboutme { get; set; }
        public DbSet<Ido> ido { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<BlogAgg> Blog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserMapping());
            modelBuilder.ApplyConfiguration(new ApplicatrionRoleMapping());
            modelBuilder.ApplyConfiguration(new PersonalsMapping());
            modelBuilder.ApplyConfiguration(new aboutmemapping());
            modelBuilder.ApplyConfiguration(new IdoMapping());
            modelBuilder.ApplyConfiguration(new SkillMapping());
            modelBuilder.ApplyConfiguration(new Blogmapping());
        }
    }
}
