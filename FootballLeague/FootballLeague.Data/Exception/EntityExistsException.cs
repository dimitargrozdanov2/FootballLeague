using System;
using System.Collections.Generic;
using System.Text;

namespace FootballLeague.Data.Exception
{
    using System;

    public class EntityExistsException : Exception
    {

        public EntityExistsException() : base(CommonExceptionCodes.EntityExists)
        {
        }

        public EntityExistsException(string message) : base(message)
        {
        }

        public EntityExistsException(string message, Exception innerException) : base(message,
             innerException)
        {
        }
    }
}
