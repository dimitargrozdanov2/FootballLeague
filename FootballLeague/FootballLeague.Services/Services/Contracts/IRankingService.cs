using FootballLeague.Models;
using FootballLeague.Services.DTOs.RankingDtos;
using System;

namespace FootballLeague.Services.Services.Contracts
{
    public interface IRankingService : ICrudService<Ranking, RankingDto, UpdateRankingDto, CreateRankingDto>
    {
    }
}
