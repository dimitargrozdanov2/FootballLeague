using AutoMapper;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Services.Services
{
    public class TeamService : CrudService<Team, TeamDto, UpdateTeamDto, CreateTeamDto>,
        ITeamService
    {
        public TeamService(IRepository<Team> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
