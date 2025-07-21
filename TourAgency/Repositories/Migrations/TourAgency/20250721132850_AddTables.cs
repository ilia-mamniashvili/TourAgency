using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations.TourAgency
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsoCode = table.Column<string>(type: "char(3)", nullable: false),
                    Flag = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tourists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalNumber = table.Column<string>(type: "char(11)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    Status_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "char(5)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    Status_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsoCode = table.Column<string>(type: "char(3)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Status_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourBookings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TouristId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourBookings_Tourists_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourBookings_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Star = table.Column<byte>(type: "tinyint", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    IncludesMeal = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Status_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelService",
                columns: table => new
                {
                    AdditionalServicesId = table.Column<int>(type: "int", nullable: false),
                    HotelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelService", x => new { x.AdditionalServicesId, x.HotelsId });
                    table.ForeignKey(
                        name: "FK_HotelService_Hotels_HotelsId",
                        column: x => x.HotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelService_Services_AdditionalServicesId",
                        column: x => x.AdditionalServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderPosition = table.Column<byte>(type: "tinyint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    Status_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourItems_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourItems_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TourItems_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelService_HotelsId",
                table: "HotelService",
                column: "HotelsId");

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_TourId",
                table: "TourBookings",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_TouristId",
                table: "TourBookings",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItems_CityId",
                table: "TourItems",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItems_HotelId",
                table: "TourItems",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_TourItems_TourId",
                table: "TourItems",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelService");

            migrationBuilder.DropTable(
                name: "TourBookings");

            migrationBuilder.DropTable(
                name: "TourItems");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}