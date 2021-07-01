using CarSales.Application.Services.Interfaces;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Interfaces.Other;
using AutoMapper;

namespace CarSales.Application.Services.Implementations
{
    public class ReviewService: IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            this._reviewRepository = reviewRepository;
            this._mapper = mapper;
        }
    }
}