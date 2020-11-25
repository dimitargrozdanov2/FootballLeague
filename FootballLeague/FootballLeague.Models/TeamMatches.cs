using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Models
{
    public class TeamMatches
    {
        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public Guid MatchId { get; set; }

        public Match Match { get; set; }
    }
}
