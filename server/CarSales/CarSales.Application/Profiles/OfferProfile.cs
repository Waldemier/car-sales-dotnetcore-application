using System.Globalization;
using AutoMapper;
using CarSales.Application.DataTrasferObjects;
using CarSales.Domain.Entities;
using CarSales.Application.Helpers;

namespace CarSales.Application.Profiles
{
    public class OfferProfile: Profile
    {
        public OfferProfile()
        {
            CreateMap<Offer, OfferDto>()
                .ForMember(dest => dest.LicensePlate,
                    opt => opt.MapFrom(src =>
                        $"{src.LicensePlate.Substring(0, 2)} {src.LicensePlate.Substring(2, 4)} {src.LicensePlate.Substring(6, 2)}"))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => 
                        src.Price.ToString("C0", new CultureInfo("en-US")).Replace(",", " ")))
                .ForMember(dest => dest.EngineType,
                    opt => opt.MapFrom(src =>
                        src.EngineType.GetEngineType()))
                .ForMember(dest => dest.Transmission, 
                    opt => opt.MapFrom(src => 
                       src.Transmission.GetTransmission()))
                .ForMember(dest => dest.Drive,
                    opt => opt.MapFrom(src => 
                        src.Drive.GetDrive()))
                .ForMember(dest => dest.DateOfferCreation,
                    opt => opt.MapFrom(src => 
                        src.DateOfferCreation.ToString("dd MMMM")));
        }
    }
}