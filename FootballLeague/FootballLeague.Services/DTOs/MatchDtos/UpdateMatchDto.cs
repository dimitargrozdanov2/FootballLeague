
using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Services.DTOs.MatchDtos
{
    public class UpdateMatchDto : IEntityDto
    {
        public Guid Id { get; set; }

    }
}
