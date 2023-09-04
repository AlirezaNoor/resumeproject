using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RES.Domin.Identity;
using RES.Domin.PersonalInformation;
using RES.Infrastructure.Mapping;

namespace RES.Infrastructure.Context
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Personal> Personals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserMapping());
            modelBuilder.ApplyConfiguration(new ApplicatrionRoleMapping());
            modelBuilder.ApplyConfiguration(new PersonalsMapping());
        }
    }
}
