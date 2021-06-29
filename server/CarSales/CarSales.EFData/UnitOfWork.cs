using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CarSales.Domain;
using CarSales.Domain.Interfaces;
using CarSales.EFData.Repositories;

namespace CarSales.EFData
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IImageRepository _imagesRepository;
        private readonly IOfferRepository _offersRepository;
        private readonly IUserRepository _usersRepository;
        private readonly IReviewRepository _reviewsRepository;
        
        public UnitOfWork(ApplicationContext context)
        {
            this._imagesRepository ??= new ImageRepository(context);
            this._offersRepository ??= new OfferRepository(context);
            this._usersRepository ??= new UserRepository(context);
            this._reviewsRepository ??= new ReviewRepository(context);
        }
        
        public IImageRepository Images => this._imagesRepository ?? throw new ArgumentNullException(nameof(this._imagesRepository));
        public IOfferRepository Offers => this._offersRepository ?? throw new ArgumentNullException(nameof(this._offersRepository));
        public IUserRepository Users => this._usersRepository ?? throw new ArgumentNullException(nameof(this._usersRepository));
        public IReviewRepository Reviews => this._reviewsRepository ?? throw new ArgumentNullException(nameof(this._reviewsRepository));
        public Task SaveChangesAsync() => this._context.SaveChangesAsync();
    }
}