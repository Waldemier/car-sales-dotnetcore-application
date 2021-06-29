using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;

namespace CarSales.EFData.Repositories
{
    public class ImageRepository: BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationContext context) : 
            base(context)
        {
        }
    }
}