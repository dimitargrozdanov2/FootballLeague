using AutoMapper;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.MatchDtos;
using FootballLeague.Services.DTOs.RankingDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Services
{
    public class MatchService : CrudService<Match, MatchDto, UpdateMatchDto, CreateMatchDto>,
        IMatchService
    {

        private readonly IRankingService rankingService;
        public MatchService(IRepository<Match> repository, IRankingService rankingService, IMapper mapper) : base(repository, mapper)
        {
            this.rankingService = rankingService;
        }

        public override async Task<MatchDto> CreateAsync(CreateMatchDto createInput)
        {
            var createdMatch = await base.CreateAsync(createInput);

            if (createInput.Date <= DateTime.UtcNow)
            {
                var homeTeam = await this.rankingService.GetSingleAsync(r => r.TeamId == createInput.HomeTeamId);
                var guestTeam = await this.rankingService.GetSingleAsync(r => r.TeamId == createInput.GuestTeamId);
                if (homeTeam != null)
                {
                    var teamRank = await rankingService.GetSingleAsync(r => r.TeamId == homeTeam.Id);
                    int pointsFromMatch = 0;
                    if (createInput.Outcome == Models.Enums.Outcome.Draw)
                    {
                        pointsFromMatch = 1;
                    }
                    else if (createInput.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        pointsFromMatch = 3;
                    }
                    else
                    {
                        pointsFromMatch = 0;
                    }
                    await this.rankingService.UpdateAsync(homeTeam.Id, new DTOs.RankingDtos.UpdateRankingDto() { Points = teamRank.Points + pointsFromMatch, MatchesPlayed = teamRank.MatchesPlayed + 1 });
                    //update
                }
                if (guestTeam != null)
                {
                    var teamRank = await rankingService.GetSingleAsync(r => r.TeamId == guestTeam.Id);

                    int pointsFromMatch = 0;
                    if (createInput.Outcome == Models.Enums.Outcome.Draw)
                    {
                        pointsFromMatch = 1;
                    }
                    else if (createInput.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        pointsFromMatch = 0;
                    }
                    else
                    {
                        pointsFromMatch = 3;
                    }
                    await this.rankingService.UpdateAsync(homeTeam.Id, new DTOs.RankingDtos.UpdateRankingDto() { Points = teamRank.Points + pointsFromMatch, MatchesPlayed = teamRank.MatchesPlayed + 1 });
                }
                else if (homeTeam == null)
                {
                    if (createInput.Outcome == Models.Enums.Outcome.Draw)
                    {
                        await rankingService.CreateAsync(new DTOs.RankingDtos.CreateRankingDto() { MatchesPlayed = 1, Points = 1, TeamId = createInput.HomeTeamId });
                    }
                    else if (createInput.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        await rankingService.CreateAsync(new DTOs.RankingDtos.CreateRankingDto() { MatchesPlayed = 1, Points = 3, TeamId = createInput.HomeTeamId });
                    }
                    else
                    {
                        await rankingService.CreateAsync(new DTOs.RankingDtos.CreateRankingDto() { MatchesPlayed = 1, Points = 0, TeamId = createInput.HomeTeamId });

                    }
                }
                else if (guestTeam == null)
                {
                    if (createInput.Outcome == Models.Enums.Outcome.Draw)
                    {
                        await rankingService.CreateAsync(new DTOs.RankingDtos.CreateRankingDto() { MatchesPlayed = 1, Points = 1, TeamId = createInput.HomeTeamId });
                    }
                    else if (createInput.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        await rankingService.CreateAsync(new DTOs.RankingDtos.CreateRankingDto() { MatchesPlayed = 1, Points = 0, TeamId = createInput.HomeTeamId });
                    }
                    else
                    {
                        await rankingService.CreateAsync(new DTOs.RankingDtos.CreateRankingDto() { MatchesPlayed = 1, Points = 3, TeamId = createInput.HomeTeamId });
                    }
                }
                var allRankings = rankingService.GetAll().Select(a => mapper.Map<UpdateRankingDto>(a)).OrderBy(r => r.Points).ToList();

                foreach (var ranking in allRankings)
                {
                    await rankingService.UpdateAsync(ranking.Id, ranking);
                }

            }
            return createdMatch;
        }
    }
}
