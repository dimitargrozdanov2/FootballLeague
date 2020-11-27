using AutoMapper;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.MatchDtos;
using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Web.Controllers
{
    public class MatchController : 
        ApiCrudController<IMatchService, Match, MatchDto, Guid, UpdateMatchDto, CreateMatchDto>
    {

        public MatchController(IMatchService matchService, IMapper mapper)
            : base(matchService, mapper)
        {
        }
    }
}
