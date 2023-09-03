using RES.Domin.Identity;
using RES.Infrastructure.Context;
using RES.Services.Interface;

namespace RES.Services.Class
{
    public class UnitOfWork:IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private GenericReposetory<ApplicationUser> _applicationuser;
        private GenericReposetory<ApplicationRole> _applicvationrole;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public GenericReposetory<ApplicationUser> UserUW
        {
            get
            {
                if (_applicationuser==null)
                {
                    _applicationuser = new GenericReposetory<ApplicationUser>(_context);
                }
                return _applicationuser;
            }
        }

        public GenericReposetory<ApplicationRole> RoleUW
        {
            get
            {
                if (_applicvationrole==null)
                {
                    _applicvationrole = new GenericReposetory<ApplicationRole>(_context);
                }

                return _applicvationrole;
            }
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public void saveasync()
        {
            _context.SaveChangesAsync();
        }
        public void Dispose()
        {
             _context.Dispose();
        }

        public ITransation Transation()
        {
            return new Transation(_context);
        }
    }
}
