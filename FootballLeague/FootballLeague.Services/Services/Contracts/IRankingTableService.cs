using FootballLeague.Models;
using FootballLeague.Services.DTOs.RankingDtos;
using System;

namespace FootballLeague.Services.Services.Contracts
{
    public interface IRankingTableService : ICrudService<Ranking, RankingDto, Guid, UpdateRankingDto, CreateRankingDto>
    {
    }
}
