using FootballLeague.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<RankingTable> RankingTable { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamMatches> TeamMatches { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Match>().HasKey(m => m.Id);
            builder.Entity<RankingTable>().HasKey(rt => rt.Id);
            builder.Entity<Team>().HasKey(t => t.Id);
            builder.Entity<TeamMatches>().HasKey(tm => new { tm.TeamId, tm.MatchId });

        }
    }
}
