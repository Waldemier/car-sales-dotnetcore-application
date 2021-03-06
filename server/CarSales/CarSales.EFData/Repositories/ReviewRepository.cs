using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;

namespace CarSales.EFData.Repositories
{
    public class ReviewRepository<T>: BaseRepository<T>, IReviewRepository where T: Review
    {
        public ReviewRepository(ApplicationContext context): 
            base(context)
        {
        }
    }
}