﻿
using FootballLeague.Models.Enums;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;

namespace FootballLeague.Services.DTOs.MatchDtos
{
    public class UpdateMatchDto : IEntityDto
    {
        public int Id { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public virtual List<TeamDto> Teams { get; set; }

        public string Venue { get; set; }

        public Outcome Outcome { get; set; }
    }
}
