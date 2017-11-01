using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WasteManegment.Api.Filters
{
    /// <inheritdoc />
    /// <summary>
    ///     Validates Model state - if invalid returns the errors
    /// </summary>
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState);

            base.OnActionExecuting(context);
        }
    }
}