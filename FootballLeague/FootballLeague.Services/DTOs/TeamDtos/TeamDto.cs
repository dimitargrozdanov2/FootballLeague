using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Services.DTOs.TeamDtos
{
    public class TeamDto : IEntityDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
