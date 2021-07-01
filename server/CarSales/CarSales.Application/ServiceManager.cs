using System;
using System.Threading.Tasks;
using AutoMapper;
using CarSales.Application.Services;
using CarSales.Application.Services.Implementations;
using CarSales.Application.Services.Interfaces;
using CarSales.Domain;
using CarSales.Domain.Interfaces.Other;

namespace CarSales.Application
{
    public class ServiceManager: IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        
        private readonly IUserService _userService;
        private readonly IOfferService _offerService;
        private readonly IReviewService _reviewService;
        private readonly IImageService _imageService;
        
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._logger = logger;
            this._offerService ??= new OfferService(this._unitOfWork.Offers, this._mapper);
            this._reviewService ??= new ReviewService(this._unitOfWork.Reviews, this._mapper);
            this._imageService ??= new ImageService(this._unitOfWork.Images, this._mapper);
            this._userService ??= new UserService(this._unitOfWork.Users, this._mapper);
        }
        
        public IUserService UserService => this._userService ?? throw new ArgumentNullException(nameof(this._userService));
        public IOfferService OfferService => this._offerService ?? throw new ArgumentNullException(nameof(this._offerService));
        public IReviewService ReviewService => this._reviewService ?? throw new ArgumentNullException(nameof(this._reviewService));
        public IImageService ImageService => this._imageService ?? throw new ArgumentNullException(nameof(this._imageService));
        
        public async Task SaveChangesAsync() => await this._unitOfWork.SaveChangesAsync();
    }
}