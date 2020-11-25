using System;

namespace FootballLeague.Data.Exceptions
{
    public class NotFoundException : Exception
    {

        public NotFoundException() : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotFoundException" /> class.
        /// </summary>
        public NotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotFoundException" /> class.
        /// </summary>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in
        ///     Visual Basic) if no inner exception is specified.
        /// </param>
        public NotFoundException(string message, Exception innerException) : base(message,
             innerException)
        {
        }
    }
}
