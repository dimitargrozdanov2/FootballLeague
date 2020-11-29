namespace FootballLeague.Data.Exception
{
    public static class CommonExceptionCodes
    {
        public static readonly string BadRequest = "BadRequest";

        public static readonly string NotFound = "Entity NotFound";

        public static readonly string NoInformationProvided = "No information provided";

        public static readonly string EntityExists = "EntityExists";

        public static readonly string ModelValidationErrors = "ModelValidationErrors";

        public static readonly string PrimaryKeyNullError = "Primary key cannot be null!";

        public static readonly string NoHomeTeamProvided = "No Valid Home Team Provided";

        public static readonly string NoGuestTeamProvided = "No Valid Guest Team Provided";

    }
}
