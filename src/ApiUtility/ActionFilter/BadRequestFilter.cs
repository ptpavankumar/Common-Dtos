using ApiUtility.Helpers.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiUtility.ActionFilter
{
    public class BadRequestFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;

            context.Result = new BadRequestObjectResult(
                BadRequestDtoHelper.GetResponseDto(context.ModelState));
        }
    }
}
