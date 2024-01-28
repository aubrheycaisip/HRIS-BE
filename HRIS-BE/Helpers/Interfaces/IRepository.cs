using HRIS_BE.Helpers.Models;
using System.Linq.Expressions;

namespace HRIS_BE.Helpers.Interfaces
{
    public interface IRepository<TEntity, IdType> where TEntity : BaseEntity where IdType : struct
    {
        void Delete(IdType id);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition);
        TEntity? GetById(IdType id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}