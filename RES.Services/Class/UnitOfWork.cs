using RES.Domin.Aboutsme;
using RES.Domin.Identity;
using RES.Domin.PersonalInformation;
using RES.Domin.Whatido;
using RES.Infrastructure.Context;
using RES.Services.Interface;

namespace RES.Services.Class
{
    public class UnitOfWork:IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private GenericReposetory<ApplicationUser> _applicationuser;
        private GenericReposetory<ApplicationRole> _applicvationrole;
        private GenericReposetory<Personal> _personal;
        private GenericReposetory<aboutme> _abouteme;
        private GenericReposetory<Ido> _ido;
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

        public GenericReposetory<Personal> PersonalUW
        {
            get
            {
                if (_personal==null)
                {
                    _personal = new GenericReposetory<Personal>(_context);
                }
                return _personal;
            }
        }

        public GenericReposetory<aboutme> aboutmeUw
        {
            get
            {
                if (_abouteme==null)
                {
                    _abouteme = new GenericReposetory<aboutme>(_context);
                }
                return _abouteme;
            }
        }

        public GenericReposetory<Ido> IdoUW
        {
            get
            {
                if (_ido==null)
                {
                    _ido = new GenericReposetory<Ido>(_context);
                }

                return _ido;
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
