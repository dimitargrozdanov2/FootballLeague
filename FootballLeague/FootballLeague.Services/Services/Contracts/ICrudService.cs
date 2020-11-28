using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.Services.Services.Contracts
{
    public interface
    ICrudService<TEntity, TEntityDto, TUpdateEntityInput, TCreateEntityInput>
    where TEntityDto : class
    where TEntity : class, IEntity
    {
        Task<TEntityDto> CreateAsync(TCreateEntityInput createInput);

        Task DeleteAsync(long primaryKey);

        Task<TEntityDto> UpdateAsync(long primaryKey, TUpdateEntityInput editInput);

        Task<TEntityDto> GetAsync(long primaryKey);

        IEnumerable<TEntityDto> GetAll(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntityDto> GetSingleAsync(Expression<Func<TEntity, bool>> filter);

    }
}
