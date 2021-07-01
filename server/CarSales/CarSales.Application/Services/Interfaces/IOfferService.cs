using System;
using System.Collections.Generic;
using CarSales.Application.DataTrasferObjects;

namespace CarSales.Application.Services.Interfaces
{
    public interface IOfferService
    {
        IEnumerable<OfferDto> GetAllOffersForResponse(bool withImages = false);
        OfferDto GetSpecificOfferForResponse(Guid Id, bool withImages = false);
    }
}