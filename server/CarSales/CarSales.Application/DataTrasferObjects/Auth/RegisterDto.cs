using System;

namespace CarSales.Application.DataTrasferObjects.Auth
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }

        public uint PhoneNumber { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public string Password { get; set; }
        
        public string Confirm { get; set; }
    }
}