using FootballLeague.Models.Enums;
using System;

namespace FootballLeague.Models
{
    public class Match : IEntity
    {
        public long Id { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public Team HomeTeam { get; set; }
        public long HomeTeamId { get; set; }
        public Team GuestTeam { get; set; }
        public long GuestTeamId { get; set; }

        public string Venue { get; set; }

        public Outcome Outcome{get; set;}


    }
}
