using AutoMapper;
using CarSales.Application.DataTrasferObjects;
using CarSales.Domain.Entities;

namespace CarSales.Application.Profiles
{
    public class ImageProfile: Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>();
        }
    }
}