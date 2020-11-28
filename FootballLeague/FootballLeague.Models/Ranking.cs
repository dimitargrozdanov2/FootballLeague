namespace FootballLeague.Models
{
    public class Ranking : IEntity
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public int Points { get; set; }

        public int MatchesPlayed { get; set; }

        public Team Team { get; set; }

        public int TeamId { get; set; }
    }
}
