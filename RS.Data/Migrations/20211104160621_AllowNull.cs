using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS.Data.Migrations
{
    public partial class AllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "CategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SeoAlias",
                table: "CategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryTranslations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573"),
                column: "ConcurrencyStamp",
                value: "add91843-789c-4a74-8171-7d30abe9603c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "08034602-b1da-4c17-b9c4-1dd06c456500");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35582832-de0b-4834-ac14-a8176635ba03", "AQAAAAEAACcQAAAAEDVPIvEN6kBGH+dEVunQVJpiHhODLMRUvNymuvKJSXt9FqdCGAM7O4LeMnLYvhcHEQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65a11ea9-0ed9-4a60-abf5-86b2ca72c6ea", "AQAAAAEAACcQAAAAEOmWkck/jkVRYK/oR8dCdi3CdAKdnsxYBlH1j96evtfDEYwobHExnCGqudsdqZtMOg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 4, 23, 4, 26, 233, DateTimeKind.Local).AddTicks(9952));
        }
    }
}
