using AutoMapper;
using FluentValidation.Results;
using FootballLeague.Data.Exception;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballLeague.Services.Services
{
    public class TeamService : CrudService<Team, TeamDto, UpdateTeamDto, CreateTeamDto>,
        ITeamService
    {
        readonly List<ValidationFailure> errors = new List<ValidationFailure>();

        public TeamService(IRepository<Team> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<TeamDto> CreateAsync(CreateTeamDto createInput)
        {
            if (String.IsNullOrEmpty(createInput.Name))
            {
                errors.Add(new ValidationFailure(nameof(createInput.Name), CommonExceptionCodes.NoInformationProvided));
                throw new ModelValidationException(errors);
            }

            return await base.CreateAsync(createInput);
        }

        public override Task<TeamDto> UpdateAsync(int primaryKey, UpdateTeamDto editInput)
        {
            if (String.IsNullOrEmpty(editInput.Name))
            {
                errors.Add(new ValidationFailure(nameof(editInput.Name), CommonExceptionCodes.NoInformationProvided));
                throw new ModelValidationException(errors);
            }

            return base.UpdateAsync(primaryKey, editInput);
        }
    }
}
