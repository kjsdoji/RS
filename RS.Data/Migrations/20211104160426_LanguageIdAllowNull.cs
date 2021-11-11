using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS.Data.Migrations
{
    public partial class LanguageIdAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "CategoryTranslations",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "CategoryTranslations",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

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
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 4, 7, 42, 3, 28, DateTimeKind.Local).AddTicks(9971));

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
