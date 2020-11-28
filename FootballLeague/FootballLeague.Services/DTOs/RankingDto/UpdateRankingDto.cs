using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;

namespace FootballLeague.Services.DTOs.RankingDtos
{
    public class UpdateRankingDto : IEntityDto
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public int Points { get; set; }

        public int GoalDifference { get; set; }

        public int MatchesPlayed { get; set; }
        public virtual List<TeamDto> Teams { get; set; }
    }
}
