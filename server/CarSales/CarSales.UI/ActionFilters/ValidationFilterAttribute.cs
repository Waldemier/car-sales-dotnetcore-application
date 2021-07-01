using System.Linq;
using CarSales.Domain.Interfaces.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarSales.UI.ActionFilters
{
    public class ValidationFilterAttribute: IActionFilter
    {
        private readonly ILoggerManager _logger;

        public ValidationFilterAttribute(ILoggerManager logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            
            var param = context.HttpContext.Items.SingleOrDefault(x => 
                    x.Value.ToString().Contains("Dto")).Value;
            
            if(param == null)
            {
                this._logger.LogInfo($"Object sent from client is null. Controller: {controller}, action {action}");
                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action {action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                this._logger.LogInfo($"Invalid model state for the object. Controller: {controller}, action {action}");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new System.NotImplementedException();
        }
    }
}