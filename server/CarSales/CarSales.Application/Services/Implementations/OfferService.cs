using System;
using System.Collections.Generic;
using CarSales.Application.Services.Interfaces;
using CarSales.Domain.Interfaces;
using CarSales.Domain.Interfaces.Other;
using AutoMapper;
using CarSales.Application.DataTrasferObjects;

namespace CarSales.Application.Services.Implementations
{
    public class OfferService: IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;
        public OfferService(IOfferRepository offerRepository, IMapper mapper)
        {
            this._offerRepository = offerRepository;
            this._mapper = mapper;
        }

        public IEnumerable<OfferDto> GetAllOffersForResponse(bool withImages = false)
        {
            var offerEntities = this._offerRepository.GetAllOffers(withImages: withImages);
            var offerDtos = this._mapper.Map<IEnumerable<OfferDto>>(offerEntities);

            return offerDtos;
        }

        public OfferDto GetSpecificOfferForResponse(Guid Id, bool withImages = false)
        {
            var offerEntity = this._offerRepository.GetSpecificOffer(Id, withImages: withImages);
            var offerDto = this._mapper.Map<OfferDto>(offerEntity);

            return offerDto;
        }
    }
}