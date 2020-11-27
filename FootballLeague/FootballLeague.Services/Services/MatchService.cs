using AutoMapper;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using FootballLeague.Services.DTOs.MatchDtos;
using FootballLeague.Services.Services.Contracts;
using System;

namespace FootballLeague.Services.Services
{
    public class MatchService : CrudService<Match, MatchDto, Guid, UpdateMatchDto, CreateMatchDto>,
        IMatchService
    {
        public MatchService(IRepository<Match> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
