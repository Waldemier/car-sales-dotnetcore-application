using System;
using System.Collections.Generic;
using CarSales.Application.DataTrasferObjects;

namespace CarSales.Application.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsersForResponse(bool withOffers = false, bool withReviews = false);
        UserDto GetUserByIdForResponse(Guid Id, bool withOffers = false, bool withReviews = false);
    }
}