using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSales.EFData.Migrations
{
    public partial class Initialdbwithdataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    GraduationYear = table.Column<long>(type: "bigint", nullable: false),
                    CityOfSale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ElectricCar = table.Column<bool>(type: "bit", nullable: false),
                    InWanted = table.Column<bool>(type: "bit", nullable: false),
                    Accident = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineType = table.Column<int>(type: "int", nullable: false),
                    EngineCapacity = table.Column<long>(type: "bigint", nullable: false),
                    Mileage = table.Column<long>(type: "bigint", nullable: false),
                    Transmission = table.Column<int>(type: "int", nullable: false),
                    Drive = table.Column<int>(type: "int", nullable: false),
                    DateOfferCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfferImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Rating", "Role" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), null, new DateTime(1800, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin", "Admin", "$2a$11$pgcc7ZkxxL8Vw1.yd9CYPu3Jft61Y7Tw7vwyPGXW61fwIQZSxFXGy", 0L, 0, 0 },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null, new DateTime(1999, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "marksh@gmail.com", "Марк", "Шульц", "$2a$11$AgnmBDzSZbGSFtT49ItBhO7AacNm7Mf/3gYKYbthwLmovZEQjZrxy", 975004932L, 0, 2 },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), null, new DateTime(1998, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "vladgan@gmail.com", "Владислав", "Гань", "$2a$11$G/MrguBCX4gFaOutCNRnBujICsvXf2xsxj8ku4e8ikAD5niLSONsq", 964002017L, 0, 1 },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), null, new DateTime(1980, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "vasilman@gmail.com", "Василь", "Маншань", "$2a$11$wYdk1WpPyGMgcfkvCHUqnecEJvwsxQmwT.TOcfjw.5ewTWT.8oKfe", 635003020L, 0, 1 },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), null, new DateTime(1981, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "arturgol@gmail.com", "Артур", "Голодов", "$2a$11$zZlB7VNo0MoKLQF4t6vy0u0BkuKr1Wfw381PXsZOQG3kYZgEsuLpW", 673006025L, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Accident", "CityOfSale", "Color", "DateOfferCreation", "Description", "Drive", "ElectricCar", "EngineCapacity", "EngineType", "GraduationYear", "InWanted", "LicensePlate", "Mark", "Mileage", "Price", "Transmission", "UserId", "VIN" },
                values: new object[] { new Guid("4a053157-3653-4fb9-9a80-1cf13f753fbb"), false, "Київ", "Чорний", new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Машина в надзвичайно хорошому стані", 2, false, 34L, 0, 2012L, false, "BС6040CP", "Bentley", 150L, 43000.0, 1, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "1C4HJWEG3DL545476" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Accident", "CityOfSale", "Color", "DateOfferCreation", "Description", "Drive", "ElectricCar", "EngineCapacity", "EngineType", "GraduationYear", "InWanted", "LicensePlate", "Mark", "Mileage", "Price", "Transmission", "UserId", "VIN" },
                values: new object[] { new Guid("05fccabb-e6b6-4cd5-aae5-75121562ddd2"), true, "Чернівці", "Чорний", new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Машина в непоганому стані", 2, false, 25L, 0, 2011L, false, "СЕ1786ВА", "Lexus", 230L, 24000.0, 1, new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "1N4AL2AP0BC131620" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Accident", "CityOfSale", "Color", "DateOfferCreation", "Description", "Drive", "ElectricCar", "EngineCapacity", "EngineType", "GraduationYear", "InWanted", "LicensePlate", "Mark", "Mileage", "Price", "Transmission", "UserId", "VIN" },
                values: new object[] { new Guid("4ccf9ec7-ebfd-4dcd-a43c-93a6681deace"), false, "Львів", "Чорний", new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Local), "Машина в хорошому стані", 1, false, 12L, 0, 2008L, false, "BB4177CH", "Audi", 200L, 11000.0, 0, new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "JN8DR09X82W636032" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_OfferId",
                table: "Images",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_LicensePlate",
                table: "Offers",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
