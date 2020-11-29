namespace FootballLeague.Data.Exception
{
    using System;

    public class NotFoundException : Exception
    {

        public NotFoundException() : base(CommonExceptionCodes.NotFound)
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message,
             innerException)
        {
        }
    }
}
