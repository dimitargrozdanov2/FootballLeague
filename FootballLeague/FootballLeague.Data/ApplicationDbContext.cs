using FootballLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Match>().HasKey(m => m.Id);
            builder.Entity<Ranking>().HasKey(rt => rt.Id);
            builder.Entity<Team>().HasKey(t => t.Id);
            builder.Entity<Match>().HasOne(m => m.GuestTeam).WithMany(m => m.GuestMatches).HasForeignKey(m => m.GuestTeamId);
            builder.Entity<Match>().HasOne(m => m.HomeTeam).WithMany(m => m.HomeMatches).HasForeignKey(m => m.HomeTeamId);

        }
    }
}
