using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS.Data.Migrations
{
    public partial class SeedDataBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "edc6549b-6d8d-4e56-9149-69ddb7631836");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a6655052-f117-4202-8039-874205bb68a9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a634ad8-8be1-425a-882d-9a90abe47431", "AQAAAAEAACcQAAAAEOqfebGn4V4F1do9tVrWcMkdvADhZuiw0qHl5+JUClaXjeAKE52NCITjDl05pnYD5g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "11747056-6b14-4e77-855f-50016bff8781", "AQAAAAEAACcQAAAAEJrEVWVc/9dJaaNoH3qmy/FqtI8iPHlQNCpidx2yFelOkwuLcA88EBP8+Vx8gDfAyw==" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "ImageName", "IsDeleted", "Name", "Type" },
                values: new object[,]
                {
                    { 1, null, false, "Test Brand 1", 1 },
                    { 2, null, false, "Test Brand 2", 1 },
                    { 3, null, false, "Test Brand 3", 1 },
                    { 4, null, false, "Test Brand 4", 2 },
                    { 5, null, false, "Test Brand 5", 2 },
                    { 6, null, false, "Test Brand 6", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 3, 10, 54, 31, 624, DateTimeKind.Local).AddTicks(9042));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "98eefb2a-fade-4ed8-86f7-633571640a8e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "98cf7da6-9176-490e-8821-d2b302b98bc6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4791daa-e68c-49f1-8c25-f561d23e2407", "AQAAAAEAACcQAAAAENIwlbwOyzsOzE+hijxx2IflQKoqOsVql4POcDhlU19OtSgVeWuZmien0xYqUO0mJg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b8f9d67-dc61-4a86-bc99-698edb990a03", "AQAAAAEAACcQAAAAEOnogdQ0SpPR/UNWun8Ih6CwLTOS00HoS22kL3K6uesrayMIX4dnOgEH5if6XlveuQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 7, 17, 17, 50, 59, 945, DateTimeKind.Local).AddTicks(1307));
        }
    }
}
