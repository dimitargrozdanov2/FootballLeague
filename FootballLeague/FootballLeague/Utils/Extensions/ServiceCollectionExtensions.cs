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
        //Add Automapper
        //Add Application Services
        public static void AddAutomapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DtoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();


            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IRankingTableService, RankingTableService>();

            services.AddTransient(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}
