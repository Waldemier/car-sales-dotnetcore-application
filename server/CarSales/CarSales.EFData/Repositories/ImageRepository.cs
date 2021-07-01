using CarSales.Domain;
using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;

namespace CarSales.EFData.Repositories
{
    public class ImageRepository<T>: BaseRepository<T>, IImageRepository where T: Image
    {
        public ImageRepository(ApplicationContext context) : 
            base(context)
        {
        }
    }
}