using System;
using System.Collections.Generic;
using System.Linq;
using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarSales.EFData.Repositories
{
    public class OfferRepository<T>: BaseRepository<T>, IOfferRepository where T: Offer
    {
        public OfferRepository(ApplicationContext context): 
            base(context)
        {
            
        }

        public IEnumerable<Offer> GetAllOffers(bool withImages)
        {
            var offers = this.GetAll();
            
            if (withImages)
                offers = offers.Include(x => x.Images);
            
            return offers.Include(x => x.User).ToList();
        }

        public Offer GetSpecificOffer(Guid Id,  bool withImages)
        {
            var offer = this.GetByCondition(o => o.Id.Equals(Id));
            
            if (withImages)
                offer = offer.Include(x => x.Images);

            return offer.Include(x => x.User).SingleOrDefault();
        }
    }
}