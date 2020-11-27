using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Data.Utils
{
    public class RepositoryFactory
    {
        public static TRepository GetRepositoryInstance<T, TRepository>()
         where TRepository : IRepository<T>, new()
         where T : class, IEntity
        {
            return new TRepository();
        }
    }
}
