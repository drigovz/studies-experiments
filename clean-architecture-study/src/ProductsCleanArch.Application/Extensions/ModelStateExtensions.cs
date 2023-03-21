using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace ProductsCleanArch.Application.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorsMessages(this ModelStateDictionary modelState) =>
            modelState
            .SelectMany(ms => ms.Value.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
    }
}
