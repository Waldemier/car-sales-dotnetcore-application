using CarSales.Domain.Entities;
using CarSales.EFData.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CarSales.EFData
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(p => p.Id);

                user.HasIndex(p => p.PhoneNumber)
                    .IsUnique();
                
                user.Property(p => p.PhoneNumber)
                    .IsRequired();
                
                user.HasIndex(p => p.Email)
                    .IsUnique();
                
                user.Property(p => p.Email)
                    .HasMaxLength(150);

                user.Property(p => p.DateOfBirth)
                    .IsRequired();

                user.Property(p => p.Password)
                    .HasMaxLength(60)
                    .IsRequired();

                user.Property(p => p.Role)
                    .IsRequired();
            });
            
            modelBuilder.Entity<Offer>(offer =>
            {
                offer.HasKey(p => p.Id);

                offer.HasIndex(p => p.LicensePlate)
                    .IsUnique();

                offer.Property(p => p.LicensePlate)
                    .IsRequired()
                    .HasMaxLength(17);

                offer.Property(p => p.Price)
                    .IsRequired();

                offer.Property(p => p.GraduationYear)
                    .IsRequired();

                offer.Property(p => p.Mark)
                    .HasMaxLength(150)
                    .IsRequired();

                offer.Property(p => p.InWanted)
                    .IsRequired();

                offer.Property(p => p.Accident)
                    .IsRequired();

                offer.Property(p => p.Mileage)
                    .IsRequired();
                
                offer.HasOne(p => p.User)
                    .WithMany(u => u.Offers)
                    .HasForeignKey(p => p.UserId);
            });
            
            modelBuilder.Entity<Image>(image =>
            {
                image.HasKey(p => p.Id);
                
                image.HasOne(p => p.Offer)
                    .WithMany(o => o.Images)
                    .HasForeignKey(p => p.OfferId);
            });

            modelBuilder.Entity<Review>(review =>
            {
                review.HasKey(p => p.Id);
                
                review.HasOne(p => p.User)
                    .WithMany(u => u.Reviews)
                    .HasForeignKey(p => p.UserId);
            });
            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
        }
    }
}