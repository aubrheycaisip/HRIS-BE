using HRIS_BE.Helpers.Interfaces;
using HRIS_BE.Helpers.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRIS_BE.Helpers.Services
{
    [ServiceDependency(serviceType: typeof(IRepository<,>))]
    public class Repository<TEntity, IdType> : IRepository<TEntity, IdType> where TEntity : BaseEntity where IdType : struct
    {
        private readonly HRISDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(HRISDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition)
        {
            return _dbSet.Where(condition).ToList();
        }

        public TEntity? GetById(IdType id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(IdType id)
        {
            TEntity? entityToDelete = _dbSet.Find(id);
            if (entityToDelete != null)
                Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
