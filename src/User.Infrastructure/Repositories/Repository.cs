using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using User.Domain.Common;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        public Repository(IServiceProvider services)
        {
            _dbContext = services.GetService<AppDbContext>();
            
            if (_dbContext is null)
                throw new NullReferenceException($"Cannot get db context!");

            _entities = _dbContext.Set<TEntity>();
        }

        public Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate) => 
            _entities.AnyAsync(predicate);
        
        public Task<TEntity> GetSingleAsync(int entityId) => 
            _entities.FirstOrDefaultAsync(e => e.Id == entityId);

        public IQueryable<TEntity> GetAll() => _entities;

        public Task CreateAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            
            _entities.Add(entity);
            
            return _dbContext.SaveChangesAsync();
        }
    }
}