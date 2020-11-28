using AutoMapper;
using FootballLeague.Data.Exceptions;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Data.Utils;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.Services.Services
{
    public class CrudService<TEntity, TEntityDto, TUpdateEntityInput, TCreateEntityInput>
        where TEntityDto : class
        where TEntity : class, IEntity
        where TUpdateEntityInput : class
        where TCreateEntityInput : class
    {

        protected readonly IMapper mapper;
        protected readonly IRepository<TEntity> repository;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CrudManager{TEntity, TEntityDto, TEntityPrimaryKey, TUpdateEntityInput, TCreateEntityInput}" /> class.
        /// </summary>
        public CrudService(IRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public virtual async Task<TEntityDto> CreateAsync(TCreateEntityInput createInput)
        {
            if (createInput == null) return null;

            var entity = mapper.Map<TEntity>(createInput);
            await repository.AddAsync(entity);
            var result = mapper.Map<TEntityDto>(entity);
            return result;
        }

        /// <inheritdoc/>
        public virtual async Task DeleteAsync(long primaryKey)
        {
            ObjectCheck.PrimaryKeyCheck(primaryKey, $"primaryKey <= 0 in {nameof(TEntity)}");
            var entityToBeDeleted = await GetAsync(primaryKey);
            if (entityToBeDeleted == null) throw new NotFoundException("Entity could not be found");
            await repository.DeleteAsync(primaryKey);
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TEntityDto> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return (repository.GetAll(filter)).Select(i => mapper.Map<TEntityDto>(i)).ToList();
        }

        /// <inheritdoc/>
        public virtual async Task<TEntityDto> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            var singleEntity = await repository.GetSingleAsync(filter);
            return singleEntity == null ? null : mapper.Map<TEntityDto>(singleEntity);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntityDto> GetAsync(long primaryKey)
        {
            ObjectCheck.PrimaryKeyCheck(primaryKey, $"primaryKey <= 0 in {nameof(TEntity)}");
            var entity = await repository.GetAsync(primaryKey);
            return entity == null ? null : mapper.Map<TEntityDto>(entity);
        }

        /// <inheritdoc/>
        public virtual async Task<TEntityDto> UpdateAsync(long primaryKey, TUpdateEntityInput editInput)
        {
            ObjectCheck.PrimaryKeyCheck(primaryKey, $"primaryKey <= 0 in {nameof(TUpdateEntityInput)}");
            var entityToBeUpdated = await repository.GetAsync(primaryKey);

            if (entityToBeUpdated == null) return null;
            mapper.Map(editInput, entityToBeUpdated);

            var result = mapper.Map<TEntityDto>(await repository.UpdateAsync(entityToBeUpdated));
            return result;
        }
    }
}
