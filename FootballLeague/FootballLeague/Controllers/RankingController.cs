using FootballLeague.Data.Exceptions;
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
    public class RankingController : Controller
    {
        private readonly IRankingService rankingService;
        public RankingController(IRankingService rankingService)
        {
            this.rankingService = rankingService;
        }

        [HttpGet("")]
        public ActionResult<List<RankingDto>> GetAll(Expression<Func<Ranking, bool>> filter = null)
        {
            var result = rankingService.GetAll(filter);
            return result.ToList();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<RankingDto>> GetSingleAsync([FromRoute] int id)
        {
            var singleEntity = await rankingService.GetAsync(id);
            if (singleEntity == null) throw new NotFoundException("Entity not found!");
            return singleEntity;
        }
    }
}
