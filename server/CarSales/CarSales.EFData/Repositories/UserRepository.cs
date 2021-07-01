using System;
using System.Collections.Generic;
using System.Linq;
using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarSales.EFData.Repositories
{
    public class UserRepository<T>: BaseRepository<T>, IUserRepository where T: User
    {
        public UserRepository(ApplicationContext context): 
            base(context)
        {
        }

        public IEnumerable<User> GetAllUsers(bool withOffers, bool withReviews)
        {
            var users = this.GetAll();
            
            if (withOffers)
                users = users.Include(x => x.Offers);

            if (withReviews)
                users = users.Include(x => x.Reviews);
            
            return users.ToList();
        }

        public User GetById(Guid Id, bool withOffers, bool withReviews)
        {
            var user = this.GetByCondition(u => u.Id.Equals(Id));
            if (withOffers)
                user = user.Include(x => x.Offers);
            if (withReviews)
                user = user.Include(x => x.Reviews);

            return user.SingleOrDefault();
        }
    }
}