using AutoMapper;
using FluentValidation.Results;
using FootballLeague.Data.Exception;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.MatchDtos;
using FootballLeague.Services.DTOs.RankingDtos;
using FootballLeague.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Services
{
    public class MatchService : CrudService<Match, MatchDto, UpdateMatchDto, CreateMatchDto>,
        IMatchService
    {

        private readonly IRankingService rankingService;
        private readonly ITeamService teamService;
        public MatchService(IRepository<Match> repository, IRankingService rankingService, ITeamService teamService, IMapper mapper) : base(repository, mapper)
        {
            this.rankingService = rankingService;
            this.teamService = teamService;
        }


        public async Task ValidateMatchDto(MatchValidateDto matchDto)
        {
            List<ValidationFailure> errors = new List<ValidationFailure>();
            if (matchDto.Date <= DateTime.UtcNow)
            {
                if (String.IsNullOrEmpty(matchDto.Result))
                    errors.Add(new ValidationFailure(nameof(matchDto.Date),CommonExceptionCodes.NoInformationProvided));
            }

            if (matchDto.Date > DateTime.UtcNow && !String.IsNullOrEmpty(matchDto.Result))
                errors.Add(new ValidationFailure(nameof(matchDto.Result), CommonExceptionCodes.NoInformationProvided));

            if (matchDto.GuestTeamId == 0 || matchDto.HomeTeamId == 0)
            {
                errors.Add(new ValidationFailure(nameof(matchDto.GuestTeamId), CommonExceptionCodes.NoInformationProvided));
            }
            if (matchDto.HomeTeamId == 0)
            {
                errors.Add(new ValidationFailure(nameof(matchDto.HomeTeamId), CommonExceptionCodes.NoInformationProvided));
            }

            var validateHomeTeam = await this.teamService.GetSingleAsync(r => r.Id == matchDto.GuestTeamId);
            var validateGuestTeam = await this.teamService.GetSingleAsync(r => r.Id == matchDto.HomeTeamId);

            if (validateHomeTeam == null)
            {
                errors.Add(new ValidationFailure(nameof(matchDto.HomeTeamId), CommonExceptionCodes.NoHomeTeamProvided));
            }
            if (validateGuestTeam == null)
            {
                errors.Add(new ValidationFailure(nameof(matchDto.GuestTeamId), CommonExceptionCodes.NoGuestTeamProvided));
            }

            if (errors.Count > 0)
            {
                throw new ModelValidationException(errors);
            }

        }

        public async Task ManipulateRankingService(MatchValidateDto matchDto)
        {
            if (matchDto.Date <= DateTime.UtcNow && !String.IsNullOrEmpty(matchDto.Result))
            {
                var homeTeamRank = await this.rankingService.GetSingleAsync(r => r.TeamId == matchDto.HomeTeamId);
                var guestTeamRank = await this.rankingService.GetSingleAsync(r => r.TeamId == matchDto.GuestTeamId);
                if (homeTeamRank != null)
                {
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
                    await this.rankingService.UpdateAsync(homeTeamRank.Id, new UpdateRankingDto() { Points = homeTeamRank.Points + pointsFromMatch, MatchesPlayed = homeTeamRank.MatchesPlayed + 1, TeamId = homeTeamRank.TeamId });
                }
                else
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
               
                if (guestTeamRank != null)
                {
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
                    await this.rankingService.UpdateAsync(guestTeamRank.Id, new UpdateRankingDto() { Points = guestTeamRank.Points + pointsFromMatch, MatchesPlayed = guestTeamRank.MatchesPlayed + 1, TeamId = guestTeamRank.TeamId });
                }

                else
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


                var allRankings = rankingService.GetAll().OrderByDescending(r => r.Points).ToList();

                for (int i = 0; i < allRankings.Count; i++)
                {
                    var mappedObject = mapper.Map<UpdateRankingDto>(allRankings[i]);
                    mappedObject.Position = i + 1;
                    await rankingService.UpdateAsync(allRankings[i].Id, mappedObject);
                }
            }
        }

        public override async Task<MatchDto> CreateAsync(CreateMatchDto createInput)
        {
            await ValidateMatchDto(createInput);
            var mappedObject = mapper.Map<Match>(createInput);
            var createdMatch = await this.repository.AddAsync(mappedObject);
            await ManipulateRankingService(createInput);
            var result = mapper.Map<MatchDto>(createdMatch);
            return result;
        }

        public override async Task<MatchDto> UpdateAsync(int primaryKey, UpdateMatchDto editInput)
        {
            await ValidateMatchDto(editInput);
            var mappedObject = mapper.Map<Match>(editInput);
            mappedObject.Id = primaryKey;
            var updatedMatch = await this.repository.UpdateAsync(mappedObject);
            await ManipulateRankingService(editInput);
            var result = mapper.Map<MatchDto>(updatedMatch);
            return result;
        }
    }
}
