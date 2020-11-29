using AutoMapper;
using FootballLeague.Data.Exception;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Services.Services
{
    public class TeamService : CrudService<Team, TeamDto, UpdateTeamDto, CreateTeamDto>,
        ITeamService
    {
        public TeamService(IRepository<Team> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<TeamDto> CreateAsync(CreateTeamDto createInput)
        {
            if (String.IsNullOrEmpty(createInput.Name))
                throw new ModelValidationException();

            return await base.CreateAsync(createInput);
        }

        public override Task<TeamDto> UpdateAsync(int primaryKey, UpdateTeamDto editInput)
        {
            if (String.IsNullOrEmpty(editInput.Name))
                throw new ModelValidationException();

            return base.UpdateAsync(primaryKey, editInput);
        }
    }
}
