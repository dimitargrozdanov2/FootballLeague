namespace FootballLeague.Models
{
    public class Ranking : IEntity
    {
        public long Id { get; set; }

        public int Position { get; set; }

        public int Points { get; set; }

        public int MatchesPlayed { get; set; }

        public Team Team { get; set; }

        public long TeamId { get; set; }
    }
}
