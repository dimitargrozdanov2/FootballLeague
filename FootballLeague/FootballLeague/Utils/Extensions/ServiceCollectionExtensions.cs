using AutoMapper;
using FootballLeague.Data;
using FootballLeague.Data.Repositories;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Services.Services;
using FootballLeague.Services.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.Web.Utils.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();


            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IRankingService, RankingService>();

            services.AddTransient(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}
