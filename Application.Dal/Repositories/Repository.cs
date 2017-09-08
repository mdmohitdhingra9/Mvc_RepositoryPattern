using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Architect.Interfaces.Core;
using System.Data.Entity;

namespace Application.Dal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<TEntity> dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbset = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbset.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            dbset.Remove(entity);
        }

        public void Delete(object id)
        {
            TEntity entity = dbset.Find(id);
            dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            dbset.Remove(entity);
        }

        public TEntity Get(object id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate=null)
        {
            if (predicate != null)
                return dbset.Where(predicate);
            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbset.ToList();
        }

        public void Update(TEntity entity)
        {
            dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
