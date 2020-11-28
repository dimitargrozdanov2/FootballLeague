using AutoMapper;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballLeague.Web.Controllers
{
    [Route("Team")]
    public class TeamController :
        ApiCrudController<ITeamService, Team, TeamDto, Guid, UpdateTeamDto, CreateTeamDto>
    {

        public TeamController(ITeamService teamService, IMapper mapper)
            : base(teamService, mapper)
    {
    }
}
}
