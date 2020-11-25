using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<TeamMatches> TeamMatches { get; set; }

        public RankingTable RankingTable { get; set; }
    }
}
