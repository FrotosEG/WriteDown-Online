using Microsoft.EntityFrameworkCore;
using WriteDownOnlineApi.Domain.Entities.Core;
using WriteDownOnlineApi.Domain.Interface.Core;

namespace WriteDownOnlineApi.Infra.Repositories.Core
{
    public class Repository<TEntity, TPK> : IRepository<TEntity, TPK> where TEntity : BaseEntity<TPK>
    {
        protected readonly Microsoft.EntityFrameworkCore.DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(Microsoft.EntityFrameworkCore.DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
            => _dbSet.ToList();

        public TEntity GetById(TPK id)
            => _dbSet.Find(id);

        public void Update(TEntity entity)
        {
            var result = _dbSet.Find(entity.Id);
            if (result != null)
                _context.Entry(result).CurrentValues.SetValues(entity);
        }

        public virtual void Delete(TPK id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public virtual void Insert(TEntity entity)
            => _dbSet.Add(entity);

        public virtual void SaveChanges()
            => _context.SaveChanges();
    }
}
