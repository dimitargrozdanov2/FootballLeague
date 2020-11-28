using FootballLeague.Models.Enums;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;

namespace FootballLeague.Services.DTOs.MatchDtos
{
    public class MatchDto : IEntityDto
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public string Venue { get; set; }

        public Outcome Outcome { get; set; }
    }
}
