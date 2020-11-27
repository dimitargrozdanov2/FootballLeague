using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.DTOs.RankingDtos
{
    public class UpdateRankingTableDto : IEntityDto
    {
        public Guid Id { get; set; }
    }
}
