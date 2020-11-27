using FootballLeague.Models;
using FootballLeague.Services.DTOs.MatchDtos;
using System;

namespace FootballLeague.Services.Services.Contracts
{
    public interface IMatchService : ICrudService<Match, MatchDto, Guid, UpdateMatchDto, CreateMatchDto>
    {
    }
}
