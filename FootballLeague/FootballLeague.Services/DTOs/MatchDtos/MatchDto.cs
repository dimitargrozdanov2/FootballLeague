using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.DTOs.MatchDtos
{
    public class MatchDto : IEntityDto
    {
        public Guid Id { get; set; }
    }
}
