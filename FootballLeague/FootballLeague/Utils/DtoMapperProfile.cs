using AutoMapper;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.MatchDtos;
using FootballLeague.Services.DTOs.RankingDtos;
using FootballLeague.Services.DTOs.TeamDtos;

namespace FootballLeague.Web.Utils
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<Match, CreateMatchDto>().ReverseMap();
            CreateMap<Match, UpdateMatchDto>().ReverseMap();

            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();

            CreateMap<Ranking, RankingDto>().ReverseMap();
            CreateMap<Ranking, CreateRankingDto>().ReverseMap();
            CreateMap<Ranking, UpdateRankingDto>().ReverseMap();
        }

    }
}
