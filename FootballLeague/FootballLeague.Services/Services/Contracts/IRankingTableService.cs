using FootballLeague.Models;
using FootballLeague.Services.DTOs.RankingDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.Services.Contracts
{
    public interface IRankingTableService : ICrudService<RankingTable, RankingTableDto, Guid, UpdateRankingTableDto, CreateRankingTableDto>
    {
    }
}
