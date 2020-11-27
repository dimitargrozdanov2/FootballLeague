using AutoMapper;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.RankingDtos;
using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Services.Services
{
    public class RankingTableService : CrudService<RankingTable, RankingTableDto, Guid, UpdateRankingTableDto, CreateRankingTableDto>,
        IRankingTableService
    {
        public RankingTableService(IRepository<RankingTable> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
