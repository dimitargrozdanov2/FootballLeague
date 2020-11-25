using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Models
{
    public class Match
    {
        public Guid Id { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public virtual List<TeamMatches> TeamMatches { get; set; }

        public string Venue { get; set; }

        public Outcome Outcome{get; set;}

    }
}
