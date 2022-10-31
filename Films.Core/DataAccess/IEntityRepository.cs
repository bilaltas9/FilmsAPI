using System.Linq.Expressions;
using Films.Core.Entities;

namespace Films.Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>>? filter = null);
        List<T> GetList(Expression<Func<T, bool>>? filter = null);
        List<T> GetIncludeList(string entityName);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
