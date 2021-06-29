using CarSales.Domain.Entities;
using CarSales.Domain.Interfaces;

namespace CarSales.EFData.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context): 
            base(context)
        {
        }
    }
}