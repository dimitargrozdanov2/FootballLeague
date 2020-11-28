using AutoMapper;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Web.Controllers
{
    public class TeamController :
        ApiCrudController<ITeamService, Team, TeamDto, Guid, UpdateTeamDto, CreateTeamDto>
    {

        public TeamController(ITeamService teamService, IMapper mapper)
            : base(teamService, mapper)
    {
    }
}
}
