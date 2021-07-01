using System;
using System.Threading.Tasks;
using CarSales.Application.Services;
using CarSales.Domain.Interfaces.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarSales.UI.ActionFilters
{
    public class ValidateUserExistsAttribute: IAsyncActionFilter
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _serviceManager;
        public ValidateUserExistsAttribute(ILoggerManager logger, IServiceManager serviceManager)
        {
            this._logger = logger;
            this._serviceManager = serviceManager;
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var Id = (Guid) context.ActionArguments["Id"];
            var userToView = this._serviceManager.UserService.GetUserByIdForResponse(Id, withOffers: true);

            if (userToView == null)
            {
                this._logger.LogInfo($"User with {Id} Id does not exist.");
                context.Result =  new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("user", userToView);
                await next();
            }
        }
    }
}