using System.Collections.Generic;

namespace CarSales.Application.DataTrasferObjects
{
    public class UserDto: BaseDto
    {
        public string FullName { get; set; }
        
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int Rating { get; set; }

        public byte[] Avatar { get; set; }
        
        public string DateOfBirth { get; set; }
        
        public IEnumerable<OfferDto> Offers { get; set; }
        
        public IEnumerable<ReviewDto> Reviews { get; set; }
    }
}