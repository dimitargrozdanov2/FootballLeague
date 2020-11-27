using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Services.DTOs.TeamDtos
{
    public class TeamDto : IEntityDto
    {
        public Guid Id { get; set; }
    }
}
