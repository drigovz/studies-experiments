using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductsCleanArch.Application.Extensions;

namespace ProductsCleanArch.Application.Filters
{
    public class ModelStateValidatorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.GetErrorsMessages();
                context.Result = new BadRequestObjectResult(errors);
            }
        }
    }
}
