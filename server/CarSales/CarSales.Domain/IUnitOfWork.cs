using System.Threading.Tasks;
using CarSales.Domain.Interfaces;

namespace CarSales.Domain
{
    public interface IUnitOfWork
    {
        IImageRepository Images { get; }
        IOfferRepository Offers { get; }
        IUserRepository Users { get; }
        IReviewRepository Reviews { get; }
        Task SaveChangesAsync();
    }
}