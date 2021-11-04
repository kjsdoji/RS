using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS.Data.Migrations
{
    public partial class AddPropertyForBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "d1c6170c-8fda-4fe3-8d4d-9d90a96822bb");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8bd62870-b628-4d77-ab8f-74564d774072");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88e7abbe-a297-4e2b-aded-f3dd8c013108", "AQAAAAEAACcQAAAAEHU6wK8Ccds3UuiHZnHs25elz/O7YjiskTfT92zFuxpZ8yl8txv9qMmWacu0c3PoqQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a5806c7-e930-4155-9064-b6f34c063336", "AQAAAAEAACcQAAAAEM9p7Ef37MLWZNgRBWxUlSbM4YdYYlql/MR2OpARRm44GOf78/bqrWfJH3Pi4SGveg==" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Description");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 4, 7, 42, 3, 28, DateTimeKind.Local).AddTicks(9971));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brands");

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 3, 10, 54, 31, 624, DateTimeKind.Local).AddTicks(9042));
        }
    }
}
