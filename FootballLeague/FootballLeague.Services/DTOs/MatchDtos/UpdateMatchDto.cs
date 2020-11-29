
using FootballLeague.Models.Enums;
using FootballLeague.Services.DTOs.TeamDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;

namespace FootballLeague.Services.DTOs.MatchDtos
{
    public class UpdateMatchDto : MatchValidateDto, IEntityDto
    {
        public int Id { get; set; }
    }
}
