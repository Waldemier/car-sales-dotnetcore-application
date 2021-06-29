using System;
using System.Collections.Generic;
using CarSales.Domain.Common;
using CarSales.Domain.Enums;

namespace CarSales.Domain.Entities
{
    public class Offer: BaseEntity
    {
        public string VIN { get; set; }
        
        public string LicensePlate { get; set; }
        
        public double Price { get; set; }
        
        public uint GraduationYear { get; set; }

        public string CityOfSale { get; set; } = "Не вказано";
        
        public string Description { get; set; }
        
        public string Mark { get; set; }
        
        public bool ElectricCar { get; set; } = false;
        
        public bool InWanted { get; set; }
        
        public bool Accident { get; set; }

        public string Color { get; set; } = "Не вказано";
        
        public EngineTypes EngineType { get; set; }
        
        public uint EngineCapacity { get; set; }
        
        public uint Mileage { get; set; }
        
        public TransmissionTypes Transmission { get; set; }
        
        public DriveTypes Drive { get; set; }
        
        public DateTime DateOfferCreation { get; set; } = DateTime.Today;
        
        public Guid UserId { get; set; }

        public User User { get; set; }
        
        public List<Image> Images { get; set; }
    }
}