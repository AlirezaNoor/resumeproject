using Microsoft.EntityFrameworkCore.Storage;
using RES.Infrastructure.Context;
using RES.Services.Interface;

namespace RES.Services.Class
{
    public class Transation: ITransation
    {
        private IDbContextTransaction _dbContextTransaction;

        public Transation(ApplicationDbContext context)
        {
            _dbContextTransaction = context.Database.BeginTransaction();
        }

        public virtual void commit()
        {
            _dbContextTransaction.Commit();
        }

        public virtual void rollback()
        {
            _dbContextTransaction.Rollback();
        }
        public void Dispose()
        {

            _dbContextTransaction.Dispose();
        }

    }
}
