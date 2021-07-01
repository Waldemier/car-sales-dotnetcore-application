using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CarSales.Domain;
using CarSales.Domain.Entities;
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
            this._context = context;
            this._imagesRepository ??= new ImageRepository<Image>(this._context);
            this._offersRepository ??= new OfferRepository<Offer>(this._context);
            this._usersRepository ??= new UserRepository<User>(this._context);
            this._reviewsRepository ??= new ReviewRepository<Review>(this._context);
        }

        public Task SaveChangesAsync() => this._context.SaveChangesAsync();
        public IImageRepository Images => this._imagesRepository ?? throw new ArgumentNullException(nameof(this._imagesRepository));
        public IOfferRepository Offers => this._offersRepository ?? throw new ArgumentNullException(nameof(this._offersRepository));
        public IUserRepository Users => this._usersRepository ?? throw new ArgumentNullException(nameof(this._usersRepository));
        public IReviewRepository Reviews => this._reviewsRepository ?? throw new ArgumentNullException(nameof(this._reviewsRepository));
    }
}