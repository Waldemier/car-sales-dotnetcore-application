using System;
using System.Collections.Generic;
using CarSales.Domain.Entities;

namespace CarSales.Domain.Interfaces
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> GetAllOffers(bool withImages);
        Offer GetSpecificOffer(Guid Id, bool withImages);
    }
}