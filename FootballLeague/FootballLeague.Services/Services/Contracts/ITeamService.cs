using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
using System;

namespace FootballLeague.Services.Services.Contracts
{
    public interface ITeamService : ICrudService<Team, TeamDto, Guid, UpdateTeamDto, CreateTeamDto>
    {
    }
}
