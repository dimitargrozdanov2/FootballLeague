using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Services.DTOs.TeamDtos
{
    public class UpdateTeamDto : IEntityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
