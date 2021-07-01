using System;
using System.Threading.Tasks;
using CarSales.Application.Services;
using CarSales.Domain.Interfaces.Other;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarSales.UI.ActionFilters
{
    public class ValidateOfferExistsAttribute: IAsyncActionFilter
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _serviceManager;
        
        public ValidateOfferExistsAttribute(ILoggerManager logger, IServiceManager serviceManager)
        {
            this._logger = logger;
            this._serviceManager = serviceManager;
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var Id = (Guid)context.ActionArguments["Id"];
            var offerToView = this._serviceManager.OfferService.GetSpecificOfferForResponse(Id, withImages: true);

            if (offerToView == null)
            {
                this._logger.LogInfo($"Offer with {Id} does not exist.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("offer", offerToView);
                await next();
            }
        }
    }
}