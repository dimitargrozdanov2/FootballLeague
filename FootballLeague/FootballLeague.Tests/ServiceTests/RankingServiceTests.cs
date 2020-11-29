using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.RankingDtos;
using FootballLeague.Services.Services;
using FootballLeague.Services.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Tests.ServiceTests
{
    [TestFixture]
    public class RankingServiceTests : BaseServiceSetup<RankingService, IRepository<Ranking>, Ranking, RankingDto,
        UpdateRankingDto, CreateRankingDto>
    {
        protected override CreateRankingDto CreateInput => new CreateRankingDto() { MatchesPlayed = 1, Points = 3, Position = 1 };

        protected override UpdateRankingDto UpdateInput => new UpdateRankingDto() { MatchesPlayed = 3, Points = 6, Position = 1 };

        protected override void SetupServices(IServiceCollection services)
        {
            base.SetupServices(services);
            services.AddSingleton(new Mock<IRankingService>().Object);
        }
    }
}
