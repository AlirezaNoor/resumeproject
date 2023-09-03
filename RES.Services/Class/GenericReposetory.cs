using Microsoft.EntityFrameworkCore;
using RES.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RES.Services.Class
{
    public class GenericReposetory<TE> where TE : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<TE> _table;

        public GenericReposetory(ApplicationDbContext context)
        {
            _context = context;
            _table = context.Set<TE>();
        }

        public virtual void insert(TE e)
        {
            _context.Add(e);
        }

        public virtual void update(TE e)
        {
            _context.Attach(e);
            _context.Entry(e).State= EntityState.Modified;
        }

        public virtual IEnumerable<TE> Get(Expression<Func<TE, bool>>? varExpression = null, string join = "")
        {
            IQueryable<TE> query = _table;
            if (varExpression!=null)
            {
                query=query.Where(varExpression);
            }

            if (!join.IsNullOrEmpty())
            {
                foreach (var j in join.Split(","))
                {
                    query = query.Include(j);
                }
            }

            return query;
        }

        public virtual TE getbyid(object id)
        {
            var ob = _table.Find(id);
            return ob;
        }

        public virtual void deletebyid(object id)
        {

            var getbyid = this.getbyid(id);

            _table.Remove(getbyid);


        }

        public virtual void Delete(TE e)
        {
            if (_context.Entry(e).State == EntityState.Detached)
            {
                _table.Attach(e);
            }

            _table.Remove(e);

        }

        public virtual void deleterange(Expression<Func<TE, bool>>? varExpression = null)
        {
            IQueryable<TE> queryable=_table;
            if (varExpression!=null)
            {
                
                queryable = queryable.Where(varExpression);
            }
            _table.RemoveRange(queryable);
        }
    }
}
