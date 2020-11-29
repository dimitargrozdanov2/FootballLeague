using AutoMapper;
using FootballLeague.Data.Exception;
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


        public void ValidateMatchDto(MatchValidateDto matchDto)
        {
            if (matchDto.Date <= DateTime.UtcNow)
            {
                if (String.IsNullOrEmpty(matchDto.Result))
                    throw new ModelValidationException();
            }

            if (matchDto.Date > DateTime.UtcNow && !String.IsNullOrEmpty(matchDto.Result))
                throw new ModelValidationException();
        }

        public async Task ManipulateRankingService(MatchValidateDto matchDto)
        {
            if (matchDto.Date <= DateTime.UtcNow && !String.IsNullOrEmpty(matchDto.Result))
            {
                var homeTeam = await this.rankingService.GetSingleAsync(r => r.TeamId == matchDto.HomeTeamId);
                var guestTeam = await this.rankingService.GetSingleAsync(r => r.TeamId == matchDto.GuestTeamId);
                if (homeTeam != null)
                {
                    var teamRank = await rankingService.GetSingleAsync(r => r.TeamId == homeTeam.Id);
                    int pointsFromMatch = 0;
                    if (matchDto.Outcome == Models.Enums.Outcome.Draw)
                    {
                        pointsFromMatch = 1;
                    }
                    else if (matchDto.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        pointsFromMatch = 3;
                    }
                    else
                    {
                        pointsFromMatch = 0;
                    }
                    await this.rankingService.UpdateAsync(homeTeam.Id, new UpdateRankingDto() { Points = teamRank.Points + pointsFromMatch, MatchesPlayed = teamRank.MatchesPlayed + 1 });
                }
                if (guestTeam != null)
                {
                    var teamRank = await rankingService.GetSingleAsync(r => r.TeamId == guestTeam.Id);

                    int pointsFromMatch = 0;
                    if (matchDto.Outcome == Models.Enums.Outcome.Draw)
                    {
                        pointsFromMatch = 1;
                    }
                    else if (matchDto.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        pointsFromMatch = 0;
                    }
                    else
                    {
                        pointsFromMatch = 3;
                    }
                    await this.rankingService.UpdateAsync(homeTeam.Id, new UpdateRankingDto() { Points = teamRank.Points + pointsFromMatch, MatchesPlayed = teamRank.MatchesPlayed + 1 });
                }
                else if (homeTeam == null)
                {
                    if (matchDto.Outcome == Models.Enums.Outcome.Draw)
                    {
                        await rankingService.CreateAsync(new CreateRankingDto() { MatchesPlayed = 1, Points = 1, TeamId = matchDto.HomeTeamId });
                    }
                    else if (matchDto.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        await rankingService.CreateAsync(new CreateRankingDto() { MatchesPlayed = 1, Points = 3, TeamId = matchDto.HomeTeamId });
                    }
                    else
                    {
                        await rankingService.CreateAsync(new CreateRankingDto() { MatchesPlayed = 1, Points = 0, TeamId = matchDto.HomeTeamId });

                    }
                }
                else if (guestTeam == null)
                {
                    if (matchDto.Outcome == Models.Enums.Outcome.Draw)
                    {
                        await rankingService.CreateAsync(new CreateRankingDto() { MatchesPlayed = 1, Points = 1, TeamId = matchDto.HomeTeamId });
                    }
                    else if (matchDto.Outcome == Models.Enums.Outcome.HomeWin)
                    {
                        await rankingService.CreateAsync(new CreateRankingDto() { MatchesPlayed = 1, Points = 0, TeamId = matchDto.HomeTeamId });
                    }
                    else
                    {
                        await rankingService.CreateAsync(new CreateRankingDto() { MatchesPlayed = 1, Points = 3, TeamId = matchDto.HomeTeamId });
                    }
                }
                var allRankings = rankingService.GetAll().Select(a => mapper.Map<UpdateRankingDto>(a)).OrderBy(r => r.Points).ToList();

                foreach (var ranking in allRankings)
                {
                    await rankingService.UpdateAsync(ranking.Id, ranking);
                }

            }
        }

        public override async Task<MatchDto> CreateAsync(CreateMatchDto createInput)
        {
            ValidateMatchDto(createInput);
            var createdMatch = await base.CreateAsync(createInput);
            await ManipulateRankingService(createInput);

            return createdMatch;
        }

        public override async Task<MatchDto> UpdateAsync(int primaryKey, UpdateMatchDto editInput)
        {
            ValidateMatchDto(editInput);
            var updatedMatch = await base.UpdateAsync(primaryKey, editInput);
            await ManipulateRankingService(editInput);

            return updatedMatch;
        }
    }
}
