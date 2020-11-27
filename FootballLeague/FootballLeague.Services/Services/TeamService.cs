using AutoMapper;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.Services
{
    public class TeamService : CrudService<Team, TeamDto, Guid, UpdateTeamDto, CreateTeamDto>,
        ITeamService
    {
        public TeamService(IRepository<Team> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
