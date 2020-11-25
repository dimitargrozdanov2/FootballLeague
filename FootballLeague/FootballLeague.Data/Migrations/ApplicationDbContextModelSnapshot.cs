﻿// <auto-generated />
using System;
using FootballLeague.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FootballLeague.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FootballLeague.Models.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Outcome")
                        .HasColumnType("integer");

                    b.Property<string>("Result")
                        .HasColumnType("text");

                    b.Property<string>("Venue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("FootballLeague.Models.RankingTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("GoalDiffrence")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RankingTable");
                });

            modelBuilder.Entity("FootballLeague.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("RankingTableId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RankingTableId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FootballLeague.Models.TeamMatches", b =>
                {
                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MatchId")
                        .HasColumnType("uuid");

                    b.HasKey("TeamId", "MatchId");

                    b.HasIndex("MatchId");

                    b.ToTable("TeamMatches");
                });

            modelBuilder.Entity("FootballLeague.Models.Team", b =>
                {
                    b.HasOne("FootballLeague.Models.RankingTable", "RankingTable")
                        .WithMany("Teams")
                        .HasForeignKey("RankingTableId");

                    b.Navigation("RankingTable");
                });

            modelBuilder.Entity("FootballLeague.Models.TeamMatches", b =>
                {
                    b.HasOne("FootballLeague.Models.Match", "Match")
                        .WithMany("TeamMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballLeague.Models.Team", "Team")
                        .WithMany("TeamMatches")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FootballLeague.Models.Match", b =>
                {
                    b.Navigation("TeamMatches");
                });

            modelBuilder.Entity("FootballLeague.Models.RankingTable", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("FootballLeague.Models.Team", b =>
                {
                    b.Navigation("TeamMatches");
                });
#pragma warning restore 612, 618
        }
    }
}