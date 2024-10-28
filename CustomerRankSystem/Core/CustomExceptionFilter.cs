using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerRankSystem.Core
{
    public class CustomExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            if (context.Exception is CustomException exception)
            {
                var result = new OutputResult(exception.ErrCode, exception.Message);
                context.Result = new JsonResult(result);
            }
            else
            {
                context.Result = new JsonResult(new OutputResult(EnumResultCode.Service_Exception, context.Exception.Message));
            }

            await Task.CompletedTask;
        }
    }
}
