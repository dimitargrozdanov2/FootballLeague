using FootballLeague.Models.Enums;
using System;

namespace FootballLeague.Models
{
    public class Match : IEntity
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public Team GuestTeam { get; set; }
        public int GuestTeamId { get; set; }

        public string Venue { get; set; }

        public Outcome Outcome{get; set;}


    }
}
