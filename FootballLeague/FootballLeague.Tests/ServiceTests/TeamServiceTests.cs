using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.TeamDtos;
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
    public class TeamServiceTests : BaseServiceSetup<TeamService, IRepository<Team>, Team, TeamDto,
      UpdateTeamDto, CreateTeamDto>
    {
        protected override CreateTeamDto CreateInput => new CreateTeamDto() { Name = "Manchester" };

        protected override UpdateTeamDto UpdateInput => new UpdateTeamDto() { Id = 1, Name = "Everton" };

        protected override void SetupServices(IServiceCollection services)
        {
            base.SetupServices(services);
            services.AddSingleton(new Mock<ITeamService>().Object);
        }
    }
}
