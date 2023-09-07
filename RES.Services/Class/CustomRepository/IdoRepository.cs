using RES.Domin.Whatido;
using RES.Infrastructure.Context;
using RES.Services.Interface.CustomRepository;

namespace RES.Services.Class.CustomRepository
{
    public class IdoRepository: IIdoRepository
    {

        private readonly ApplicationDbContext _context;

        public IdoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void create(List<Ido> idos)
        {
            _context.ido.AddRange(idos);
            _context.SaveChanges();
        }
    }
}
