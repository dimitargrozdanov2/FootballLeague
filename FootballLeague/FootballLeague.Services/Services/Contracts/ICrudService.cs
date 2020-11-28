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

        Task DeleteAsync(int primaryKey);

        Task<TEntityDto> UpdateAsync(int primaryKey, TUpdateEntityInput editInput);

        Task<TEntityDto> GetAsync(int primaryKey);

        IEnumerable<TEntityDto> GetAll(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntityDto> GetSingleAsync(Expression<Func<TEntity, bool>> filter);

    }
}
