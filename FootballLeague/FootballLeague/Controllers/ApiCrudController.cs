using AutoMapper;
using FootballLeague.Data.Exception;
using FootballLeague.Models;
using FootballLeague.Services.Services.Contracts;
using FootballLeague.Web.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.Web.Controllers
{
    public class ApiCrudController<TService, TEntity, TEntityDto, TUpdateEntityInput, TCreateEntityInput> : ControllerBase
       where TService : class, ICrudService<TEntity, TEntityDto, TUpdateEntityInput, TCreateEntityInput>
       where TEntityDto : class, IEntityDto
       where TUpdateEntityInput : class, IEntityDto
       where TEntity : class, IEntity
    {
        protected readonly TService service;
        protected readonly IMapper mapper;

        public ApiCrudController(TService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<List<TEntityDto>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var result = service.GetAll(filter);
            return result.ToList();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntityDto>> GetSingleAsync([FromRoute] int id)
        {
            if (id == 0)
            {
                throw new ModelValidationException();
            }
            var singleEntity = await service.GetAsync(id);
            if (singleEntity == null) throw new NotFoundException(CommonExceptionCodes.NotFound);
            return singleEntity;
        }

        [HttpPost("")]
        public virtual async Task<ActionResult<TEntityDto>> CreateAsync([FromBody] TCreateEntityInput createEntityInput)
        {
            if (createEntityInput == null)
            {
                throw new ModelValidationException();
            }
            var item = await service.CreateAsync(createEntityInput);
            if (item == null) throw new NotFoundException(CommonExceptionCodes.NoInformationProvided);
            return Created($"{Url?.ActionLink()}/{item}", item);
        }

        [HttpPut("")]
        public virtual async Task<ActionResult<TEntityDto>> UpdateAsync([FromBody] TUpdateEntityInput updateEntityInput)
        {
            if (updateEntityInput == null)
            {
                throw new ModelValidationException();
            }
            var entityToBeUpdatedDto = await service.UpdateAsync(updateEntityInput.Id, updateEntityInput);

            if (entityToBeUpdatedDto == null) throw new NotFoundException($"{typeof(TEntity).Name} not found!");

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<TEntityDto>> DeleteAsync([FromRoute] int id)
        {
            if (id == 0)
            {
                throw new ModelValidationException();
            }
            await service.DeleteAsync(id);
            return NoContent();
        }

    }
}
