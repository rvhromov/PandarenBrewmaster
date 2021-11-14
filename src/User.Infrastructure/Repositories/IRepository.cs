using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetSingleAsync(int entityId);

        IQueryable<TEntity> GetAll();

        Task CreateAsync(TEntity entity);
    }
}