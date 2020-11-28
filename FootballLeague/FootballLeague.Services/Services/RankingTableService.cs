using AutoMapper;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.RankingDtos;
using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Services.Services
{
    public class RankingTableService : CrudService<Ranking, RankingDto, Guid, UpdateRankingDto, CreateRankingDto>,
        IRankingTableService
    {
        public RankingTableService(IRepository<Ranking> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
