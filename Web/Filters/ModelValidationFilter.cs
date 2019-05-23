using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Web.Filters
{
    public class ModelValidationFilter:IAsyncPageFilter
    {
        public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            await Task.CompletedTask;
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,PageHandlerExecutionDelegate next)
        {
            if(context.HttpContext.Request.Method.Equals("POST") || context.HttpContext.Request.Method.Equals("PUT"))
            {
                if(!context.ModelState.IsValid)
                {
                    //if(context.HttpContext.Request.IsAjaxRequest())
                    //{
                    //    var errorModel = context.ModelState.Keys.Where(x => context.ModelState[x].Errors.Count > 0)
                    //        .Select(x => new {
                    //            key = x,
                    //            errors = context.ModelState[x].Errors.Select(y => y.ErrorMessage).ToArray()
                    //        });

                    //    context.Result = new JsonResult(new AjaxResultHelper<IEnumerable<object>> {
                    //        Response = errorModel,
                    //        Message = "_InvalidData_"
                    //    });
                    //} else
                    //{
                    // TODO: For Page Submit
                    //var result = (PageResult)context.Result;

                    ////if (result is PageResult pageResult)
                    ////{
                    //context.Result = new PageResult
                    //{
                    //    ViewData = result.ViewData,
                    //    //Model = pageResult.Model,
                    //    ContentType = result.ContentType,
                    //    StatusCode = 400,
                    //    //Page = pageResult.Page
                    //};
                    ////}

                    //context.Result = new BadRequestObjectResult(context.ModelState);
                    //await next.Invoke();

                    var result = context.HandlerInstance as PageModel;

                    context.Result = new PageResult {
                        ViewData = result?.ViewData,
                        ContentType = result?.Request.ContentType,
                        StatusCode = 400,
                    };
                    //}
                } else
                {
                    await next.Invoke();
                }
            } else
            {
                await next.Invoke();
            }
        }
    }
}
