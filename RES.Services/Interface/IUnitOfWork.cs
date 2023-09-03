using RES.Domin.Identity;
using RES.Services.Class;

namespace RES.Services.Interface
{
    public interface IUnitOfWork
    {
        GenericReposetory<ApplicationUser> UserUW { get; }
        GenericReposetory<ApplicationRole> RoleUW { get; }
        void save();
        void saveasync();
    }
}
