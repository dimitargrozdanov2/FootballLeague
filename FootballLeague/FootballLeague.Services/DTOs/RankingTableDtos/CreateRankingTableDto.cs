using FootballLeague.Services.DTOs.TeamDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.DTOs.RankingDtos
{
    public class CreateRankingTableDto
    {
        public int Position { get; set; }

        public int Points { get; set; }

        public int GoalDifference { get; set; }

        public int MatchesPlayed { get; set; }
        public virtual List<TeamDto> Teams { get; set; }
    }
}
