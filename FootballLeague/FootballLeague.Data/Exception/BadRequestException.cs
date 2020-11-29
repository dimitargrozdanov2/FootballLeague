namespace FootballLeague.Data.Exception
{
    using System;

    public class BadRequestException : Exception
    {

        public BadRequestException() : base(CommonExceptionCodes.BadRequest)
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message,
             innerException)
        {
        }
    }
}
