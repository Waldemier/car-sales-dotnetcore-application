using AutoMapper;
using CarSales.Application.DataTrasferObjects;
using CarSales.Domain.Entities;

namespace CarSales.Application.Profiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>();
        }
    }
}