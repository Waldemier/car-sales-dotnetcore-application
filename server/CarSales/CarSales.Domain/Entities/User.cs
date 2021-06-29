using System;
using System.Collections.Generic;
using CarSales.Domain.Common;
using CarSales.Domain.Enums;

namespace CarSales.Domain.Entities
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public string PhoneNumber { get; set; } = null;

        public int Rating { get; set; } = 0;

        public byte[] Avatar { get; set; } = null;
        
        public DateTime DateOfBirth { get; set; }
        
        public string Password { get; set; }
        
        public RoleTypes Role { get; set; }
        
        public List<Offer> Offers { get; set; }
        
        public List<Review> Reviews { get; set; }
    }
}