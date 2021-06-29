using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;

namespace CarSales.EFData.Repositories
{
    public class OfferRepository: BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(ApplicationContext context): 
            base(context)
        {
            
        }
    }
}