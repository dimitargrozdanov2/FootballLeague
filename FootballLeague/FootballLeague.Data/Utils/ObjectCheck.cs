using FootballLeague.Data.Exception;
using FootballLeague.Models;

namespace FootballLeague.Data.Utils
{
    public static class ObjectCheck
    {
        public static void EntityCheck(IEntity entity, string message = null)
        {
            if (entity == null)
            {
                if (message == null)
                    message = CommonExceptionCodes.NotFound;

                throw new NotFoundException(message);
            }
        }

        public static void PrimaryKeyCheck(object primaryKey, string message = null)
        {
            if (primaryKey == null || primaryKey.ToString() == "0")
            {
                if (message == null)
                    message = CommonExceptionCodes.PrimaryKeyNullError;
                throw new NotFoundException(message);
            }
        }
    }
}
