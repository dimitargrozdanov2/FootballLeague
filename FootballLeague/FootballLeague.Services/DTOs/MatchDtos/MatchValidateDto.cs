using FootballLeague.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.DTOs.MatchDtos
{
    public class MatchValidateDto
    {
        public string Result { get; set; }

        public DateTime Date { get; set; }

        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public string Venue { get; set; }

        public Outcome Outcome { get; set; }
    }
}
