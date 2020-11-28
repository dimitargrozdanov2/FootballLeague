using AutoMapper;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.MatchDtos;
using FootballLeague.Services.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FootballLeague.Web.Controllers
{
    [Route("Match")]
    public class MatchController : 
        ApiCrudController<IMatchService, Match, MatchDto, UpdateMatchDto, CreateMatchDto>
    {

        public MatchController(IMatchService matchService, IMapper mapper)
            : base(matchService, mapper)
        {
        }
    }
}
