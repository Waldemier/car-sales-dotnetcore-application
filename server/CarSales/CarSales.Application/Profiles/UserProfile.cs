using AutoMapper;
using CarSales.Application.DataTrasferObjects;
using CarSales.Application.Helpers;
using CarSales.Domain.Entities;

namespace CarSales.Application.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => 
                        $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PhoneNumber,
                    opt => opt.MapFrom(src => 
                        GeneralHelpers.GetPhoneFormat(src.PhoneNumber)))
                .ForMember(dest => dest.DateOfBirth,
                    opt => opt.MapFrom(src => 
                        src.DateOfBirth.ToString("dd.MM.yyyy")));

        }
    }
}