using FootballLeague.Data.Exceptions;
using FootballLeague.Data.Repositories.Contracts;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Data.Utils
{
    public static class ObjectCheck
    {
        public static void EntityCheck(IEntity entity, string message = null)
        {
            if (entity == null)
            {
                if (message == null)
                    message = "Entity was not found!";

                throw new NotFoundException(message);
            }
        }

        //public static void EntityCheck(IDto entityDto, string message = null)
        //{
        //    if (entityDto == null)
        //    {
        //        if (message == null)
        //            message = "Dto was not found!";

        //        throw new NotFoundException(message);
        //    }

        //}

        public static void PrimaryKeyCheck(object primaryKey, string message = null)
        {
            if (primaryKey == null || primaryKey.ToString() == "0")
            {
                if (message == null)
                    message = "Primary key cannot be null!";
                throw new NotFoundException(message);
            }
        }
    }
}
