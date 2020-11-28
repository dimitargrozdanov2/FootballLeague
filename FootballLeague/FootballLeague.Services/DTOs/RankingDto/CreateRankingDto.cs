using FootballLeague.Services.DTOs.TeamDtos;
using System.Collections.Generic;

namespace FootballLeague.Services.DTOs.RankingDtos
{
    public class CreateRankingDto
    {
        public int Position { get; set; }

        public int Points { get; set; }

        public int MatchesPlayed { get; set; }
        public long TeamId { get; set; }
    }
}
