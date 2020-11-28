using System.Collections.Generic;

namespace FootballLeague.Models
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Match> HomeMatches { get; set; }
        public List<Match> GuestMatches { get; set; }

    }
}
