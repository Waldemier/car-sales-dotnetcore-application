using System;
using System.Globalization;
using CarSales.Domain.Entities;
using CarSales.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.EFData.Configuration
{
    public class OfferConfiguration: IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasData(
                new Offer
                {
                    Id = new Guid("05fccabb-e6b6-4cd5-aae5-75121562ddd2"),
                    VIN = "1N4AL2AP0BC131620",
                    LicensePlate = new string("СЕ1786ВА").ToUpper(),
                    Price = 24000,
                    GraduationYear = 2011,
                    CityOfSale = "Чернівці",
                    Description = "Машина в непоганому стані",
                    Mark = "Lexus",
                    InWanted = false,
                    Accident = true,
                    Color = "Чорний",
                    EngineType = EngineTypes.Fuel,
                    EngineCapacity = 25,
                    Mileage = 230,
                    Transmission = TransmissionTypes.AutomaticTransmission,
                    Drive = DriveTypes.AllWheelDrive,
                    UserId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
                },
                new Offer
                {
                    Id = new Guid("4a053157-3653-4fb9-9a80-1cf13f753fbb"),
                    VIN = "1C4HJWEG3DL545476",
                    LicensePlate = new string("BС6040CP").ToUpper(),
                    Price = 43000,
                    GraduationYear = 2012,
                    CityOfSale = "Київ",
                    Description = "Машина в надзвичайно хорошому стані",
                    Mark = "Bentley",
                    InWanted = false,
                    Accident = false,
                    Color = "Чорний",
                    EngineType = EngineTypes.Fuel,
                    EngineCapacity = 34,
                    Mileage = 150,
                    Transmission = TransmissionTypes.AutomaticTransmission,
                    Drive = DriveTypes.AllWheelDrive,
                    UserId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Offer
                {
                    Id = new Guid("4ccf9ec7-ebfd-4dcd-a43c-93a6681deace"),
                    VIN = "JN8DR09X82W636032",
                    LicensePlate = new string("BB4177CH").ToUpper(),
                    Price = 11000,
                    GraduationYear = 2008,
                    CityOfSale = "Львів",
                    Description = "Машина в хорошому стані",
                    Mark = "Audi",
                    InWanted = false,
                    Accident = false,
                    Color = "Чорний",
                    EngineType = EngineTypes.Fuel,
                    EngineCapacity = 12,
                    Mileage = 200,
                    Transmission = TransmissionTypes.ManualTransmission,
                    Drive = DriveTypes.RearWheelDrive,
                    UserId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                }
            );
        }
    }
}