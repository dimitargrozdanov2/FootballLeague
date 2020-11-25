using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Models
{
    public class RankingTable
    {
        public Guid Id { get; set; }

        public int Position { get; set; }

        public int Points { get; set; }

        public int GoalDiffrence { get; set; }

        public virtual List<Team> Teams { get; set; }

    }
}
