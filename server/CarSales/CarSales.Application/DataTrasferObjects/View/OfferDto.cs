using System.Collections.Generic;

namespace CarSales.Application.DataTrasferObjects
{
    public class OfferDto: BaseDto
    {
        public string VIN { get; set; }
        
        public string LicensePlate { get; set; }
        
        public string Price { get; set; }
        
        public uint GraduationYear { get; set; }

        public string CityOfSale { get; set; } = "Не вказано";
        
        public string Description { get; set; }
        
        public string Mark { get; set; }
        
        public bool ElectricCar { get; set; }
        
        public bool InWanted { get; set; }
        
        public bool Accident { get; set; }

        public string Color { get; set; } = "Не вказано";
        
        public string EngineType { get; set; }
        
        public uint EngineCapacity { get; set; }
        
        public uint Mileage { get; set; }
        
        public string Transmission { get; set; }
        
        public string Drive { get; set; }
        
        public string DateOfferCreation { get; set; }
        
        public UserDto User { get; set; }
        
        public List<ImageDto> Images { get; set; }
    }
}