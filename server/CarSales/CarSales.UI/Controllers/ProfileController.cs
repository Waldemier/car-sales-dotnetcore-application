using System;
using CarSales.Application.DataTrasferObjects;
using CarSales.Application.Services;
using CarSales.Domain.Interfaces.Other;
using CarSales.UI.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/{Id:Guid}")]
    public class ProfileController: ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _serviceManager;
        
        public ProfileController(IServiceManager serviceManager, ILoggerManager logger)
        {
            this._serviceManager = serviceManager;
            this._logger = logger;
        }

        [HttpGet]
        [ServiceFilter(typeof(ValidateUserExistsAttribute))]
        public IActionResult GetSpecificUser(Guid Id)
        {
            var userToView = HttpContext.Items["user"] as UserDto;
            return Ok(userToView);
        }
    }
}