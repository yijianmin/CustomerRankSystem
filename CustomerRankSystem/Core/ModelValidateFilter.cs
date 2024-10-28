using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerRankSystem.Core
{
    public class ModelValidateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                var errors = (from m in modelState
                              where modelState[m.Key].Errors.Any()
                              select string.Join(";", m.Value.Errors.Select(t => t.ErrorMessage))).ToList();

                var modelValidateError = errors.FirstOrDefault();
                throw new CustomException(EnumResultCode.Parameter_Invalid, modelValidateError);
            }
            await next();
        }
    }
}
