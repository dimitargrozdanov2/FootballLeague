using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Data.Utils;
using FootballLeague.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.Data.Repositories
{
    public class DbRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext dbContext;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DbRepository{TEntity}" /> class.
        /// </summary>
        public DbRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            ObjectCheck.EntityCheck(entity, $"{nameof(TEntity)} missing.");
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetAsync(int primaryKey)
        {
            ObjectCheck.PrimaryKeyCheck(primaryKey, $"primaryKey <= 0 in {nameof(IRepository<TEntity>)}");
            return await dbContext.Set<TEntity>().FindAsync(primaryKey);
        }

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return (filter != null ? dbContext.Set<TEntity>().Where(filter) : dbContext.Set<TEntity>());
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dbContext.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            ObjectCheck.EntityCheck(entity, $"{nameof(TEntity)} missing.");
            dbContext.Set<TEntity>().Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        /// <inheritdoc/>
        public virtual async Task DeleteAsync(int primaryKey)
        {
            var entityToBeDeleted = await GetAsync(primaryKey);
            ObjectCheck.EntityCheck(entityToBeDeleted, $"{nameof(TEntity)} missing.");

            dbContext.Set<TEntity>().Remove(entityToBeDeleted);
            await dbContext.SaveChangesAsync();
        }
    }
}