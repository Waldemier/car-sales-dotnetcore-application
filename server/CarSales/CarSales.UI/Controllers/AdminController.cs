using System;
using CarSales.Application.Services;
using CarSales.Domain.Interfaces.Other;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _serviceManager;
        
        public AdminController(ILoggerManager logger, IServiceManager serviceManager)
        {
            this._logger = logger;
            this._serviceManager = serviceManager;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var usersToView = this._serviceManager.UserService.GetAllUsersForResponse(withOffers: true);
            
            return Ok(usersToView);
        }
    }
}