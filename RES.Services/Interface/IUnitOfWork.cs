using RES.Domin.Identity;
using RES.Domin.PersonalInformation;
using RES.Services.Class;

namespace RES.Services.Interface
{
    public interface IUnitOfWork
    {
        GenericReposetory<ApplicationUser> UserUW { get; }
        GenericReposetory<ApplicationRole> RoleUW { get; }
        GenericReposetory<Personal> PersonalUW { get; }
        void save();
        void saveasync();
    }
}
