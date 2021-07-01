using CarSales.Application.Services.Interfaces;
using CarSales.Domain.Interfaces;
using AutoMapper;
using CarSales.Domain.Interfaces.Other;

namespace CarSales.Application.Services.Implementations
{
    public class ImageService: IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            this._imageRepository = imageRepository;
            this._mapper = mapper;
        }
    }
}