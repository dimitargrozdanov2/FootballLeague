using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Web.Utils.Extensions
{
    public static class ValidationExceptionHandlerMiddleWareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
          => builder.UseMiddleware<ValidationExceptionHandlerMiddleware>();
    }
}
