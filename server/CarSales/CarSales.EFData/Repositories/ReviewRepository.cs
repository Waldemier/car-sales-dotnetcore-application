using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;

namespace CarSales.EFData.Repositories
{
    public class ReviewRepository: BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationContext context): 
            base(context)
        {
        }
    }
}