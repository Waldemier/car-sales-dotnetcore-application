using System;
using CarSales.Application.DataTrasferObjects;
using CarSales.Application.Helpers;
using CarSales.Application.Services;
using CarSales.Domain.Interfaces.Other;
using CarSales.UI.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _serviceManager;
        
        public OffersController(ILoggerManager logger, IServiceManager serviceManager)
        {
            this._logger = logger;
            this._serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllOffers()
        {
            var offersToView = this._serviceManager.OfferService.GetAllOffersForResponse(withImages: true);
            
            return Ok(offersToView);
        }

        [HttpGet("{Id:Guid}", Name = "GetSpecificOffer")]
        [ServiceFilter(typeof(ValidateOfferExistsAttribute))]
        public IActionResult GetSpecificOffer(Guid Id)
        {
            var offerToView = HttpContext.Items["offer"] as OfferDto;
            return Ok(offerToView);
        }
        
    }
}