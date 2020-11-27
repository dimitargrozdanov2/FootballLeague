using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Services.Services.Contracts
{
    public interface
    ICrudService<TEntity, TEntityDto, Guid, TUpdateEntityInput, TCreateEntityInput>
    where TEntityDto : class
    where TEntity : class, IEntity
    {
        Task<TEntityDto> CreateAsync(TCreateEntityInput createInput);

        Task DeleteAsync(Guid primaryKey);

        Task<TEntityDto> UpdateAsync(System.Guid primaryKey, TUpdateEntityInput editInput);

        Task<TEntityDto> GetAsync(Guid primaryKey);

        IEnumerable<TEntityDto> GetAll(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntityDto> GetSingleAsync(Expression<Func<TEntity, bool>> filter);

    }
}
