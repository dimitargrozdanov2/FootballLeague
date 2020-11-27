using FootballLeague.Models;
using FootballLeague.Models.Enums;
using FootballLeague.Services.DTOs.TeamDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.DTOs.MatchDtos
{
    public class CreateMatchDto
    {
        public string Result { get; set; }

        public DateTime Date { get; set; }

        public virtual List<TeamDto> Teams { get; set; }

        public string Venue { get; set; }

        public Outcome Outcome { get; set; }
    }
}
