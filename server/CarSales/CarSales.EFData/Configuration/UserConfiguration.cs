using System;
using CarSales.Domain.Entities;
using CarSales.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.EFData.Configuration
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@gmail.com",
                    DateOfBirth = new DateTime(1800, 8, 8),
                    Password = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    PhoneNumber = 0000000000,
                    Role = RoleTypes.Admin
                },
                new User
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    FirstName = "Марк",
                    LastName = "Шульц",
                    Email = "marksh@gmail.com",
                    DateOfBirth = new DateTime(1999, 2, 18),
                    Password = BCrypt.Net.BCrypt.HashPassword("12345@Vv"),
                    PhoneNumber =  0975004932,
                    Role = RoleTypes.Manager
                },
                new User
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    FirstName = "Владислав",
                    LastName = "Гань",
                    Email = "vladgan@gmail.com",
                    DateOfBirth = new DateTime(1998, 5, 7),
                    Password = BCrypt.Net.BCrypt.HashPassword("12345@Vv"),
                    PhoneNumber = 0964002017,
                    Role = RoleTypes.Seller
                },
                new User
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FirstName = "Василь",
                    LastName = "Маншань",
                    Email = "vasilman@gmail.com",
                    DateOfBirth = new DateTime(1980, 4, 10),
                    Password = BCrypt.Net.BCrypt.HashPassword("12345@Vv"),
                    PhoneNumber = 0635003020,
                    Role = RoleTypes.Seller
                },
                new User
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    FirstName = "Артур",
                    LastName = "Голодов",
                    Email = "arturgol@gmail.com",
                    DateOfBirth = new DateTime(1981, 2, 3),
                    Password = BCrypt.Net.BCrypt.HashPassword("12345@Vv"),
                    PhoneNumber = 0673006025,
                    Role = RoleTypes.Seller
                }
            );
        }
    }
}