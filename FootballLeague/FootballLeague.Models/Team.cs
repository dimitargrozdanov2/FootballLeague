using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Models
{
    public class Team : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<TeamMatches> TeamMatches { get; set; }

        public RankingTable RankingTable { get; set; }
    }
}
