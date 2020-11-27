﻿using AutoMapper;
using FootballLeague.Data.Exceptions;
using FootballLeague.Models;
using FootballLeague.Services.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.Web.Controllers
{
    public class ApiCrudController<TService, TEntity, TEntityDto, Guid, TUpdateEntityInput, TCreateEntityInput> : ControllerBase
       where TService : class, ICrudService<TEntity, TEntityDto, Guid, TUpdateEntityInput, TCreateEntityInput>
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
        public IActionResult GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // to be implemented
            return Ok();
        }

        [HttpGet("{id}")]
        public virtual async Task<TEntityDto> GetSingleAsync([FromRoute] Guid id)
        {
            var singleEntity = await service.GetAsync(id);
            if (singleEntity == null) throw new NotFoundException("Entity not found!");
            return singleEntity;
        }

        [HttpPost("")]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TCreateEntityInput createEntityInput)
        {

            var item = await service.CreateAsync(createEntityInput);
            if (item == null) throw new NotFoundException("No create information provided!");
            return Created($"{Url?.ActionLink()}/{item}", item);
        }

        [HttpPut("")]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] TUpdateEntityInput updateEntityInput)
        {

            var entityToBeUpdatedDto = await service.UpdateAsync(updateEntityInput.Id, updateEntityInput);

            if (entityToBeUpdatedDto == null) throw new NotFoundException($"{typeof(TEntity).Name} not found!");

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }

    }
}