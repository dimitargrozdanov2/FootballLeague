using FootballLeague.Data.Exception;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.RankingDtos;
using FootballLeague.Services.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.Web.Controllers
{
    [Route("Ranking")]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService rankingService;
        public RankingController(IRankingService rankingService)
        {
            this.rankingService = rankingService;
        }

        [HttpGet("")]
        public ActionResult<List<RankingDto>> GetAll()
        {
            var result = rankingService.GetAll(null);
            return result.ToList();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<RankingDto>> GetSingleAsync([FromRoute] int id)
        {
            var singleEntity = await rankingService.GetAsync(id);
            if (singleEntity == null) throw new NotFoundException(CommonExceptionCodes.NotFound);
            return singleEntity;
        }
    }
}
