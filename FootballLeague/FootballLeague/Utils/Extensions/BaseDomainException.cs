using System;

namespace FootballLeague.Web.Utils.Extensions
{
    public abstract class BaseDomainException : Exception
    {
        private string? error;

        public string Error
        {
            get => this.error ?? base.Message;
            set => this.error = value;
        }
    }
}
