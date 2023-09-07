using RES.Domin.Aboutsme;
using RES.Domin.Identity;
using RES.Domin.PersonalInformation;
using RES.Domin.Whatido;
using RES.Services.Class;

namespace RES.Services.Interface
{
    public interface IUnitOfWork
    {
        GenericReposetory<ApplicationUser> UserUW { get; }
        GenericReposetory<ApplicationRole> RoleUW { get; }
        GenericReposetory<Personal> PersonalUW { get; }
        GenericReposetory<aboutme> aboutmeUw { get; }
        public GenericReposetory<Ido> IdoUW { get; }
        void save();
        void saveasync();
    }
}
