
using System.Threading.Tasks;
using CarSales.Application.Services.Interfaces;

namespace CarSales.Application.Services
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IOfferService OfferService { get; }
        IReviewService ReviewService { get; }
        IImageService ImageService { get; }
        Task SaveChangesAsync();
    }
}