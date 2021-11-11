using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS.Data.Migrations
{
    public partial class ResetDataFeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsShowOnHome",
                table: "Categories",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "6858ace8-d178-44f1-ad89-2de9be5cc075");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "accb2ee3-0fed-49f9-88fe-78c3d28b82ba");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2142230-5c28-47ae-8cb3-1b026bbc14db", "AQAAAAEAACcQAAAAEHSlxXEd9bU+opWvJrWWiMhTy/vXlX5fclW4GRe5PZIj1JG93wIleBZCmw9HKqQHpw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "358ae13e-db05-4b94-a07d-4f867df8cac4", "AQAAAAEAACcQAAAAEINub359dRcFAHcNOnuYGgfGg4DhsQKku9g0fZMsG1N8Mn7Dc1iIedt1wx38c+h6sg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 5, 10, 44, 29, 20, DateTimeKind.Local).AddTicks(1539));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "SortOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShowOnHome",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "e6fac700-05ae-4050-b07c-629efb5b6205");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "91087345-b15c-4c86-a0ad-7d3d64e77591");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ca00def-923d-42f3-a333-873ad0177d5c", "AQAAAAEAACcQAAAAENa7PkfGZ2YrMDKUnfQAOBhh6Tl1HHKcbGzgdvp0RA2r1NfrZ4nBz7Lag3NX9JXHXQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "68f3f27e-1158-4922-a8d3-679a8a8e5c9f", "AQAAAAEAACcQAAAAEIlm7yy1hGoZ8ENbLfeVFEelN3qsdHIGrqaazfH0xgL4/vA3d/6LXfU0LTQJbJA4CA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 4, 23, 6, 21, 120, DateTimeKind.Local).AddTicks(9588));
        }
    }
}
