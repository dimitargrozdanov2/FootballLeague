using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.DTOs.RankingDtos
{
    public class RankingTableDto : IEntityDto
    {
        public Guid Id { get; set; }
    }
}
