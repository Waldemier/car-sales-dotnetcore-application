using System;
using System.Collections.Generic;
using CarSales.Domain.Entities;

namespace CarSales.Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(bool withOffers, bool withReviews);
        User GetById(Guid Id, bool withOffers, bool withReviews);
    }
}