using System;
using System.Collections.Generic;
using System.Text;
using RS.Data.Entities;
using RS.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RS.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region SeedDataBrand
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Test Brand 1",
                    Type = (int)BrandTypeEnum.Normal,
                    Description = "Description"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Test Brand 2",
                    Type = (int)BrandTypeEnum.Normal,
                    Description = "Description"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Test Brand 3",
                    Type = (int)BrandTypeEnum.Normal,
                    Description = "Description"
                },
                new Brand
                {
                    Id = 4,
                    Name = "Test Brand 4",
                    Type = (int)BrandTypeEnum.Luxury,
                    Description = "Description"
                },
                new Brand
                {
                    Id = 5,
                    Name = "Test Brand 5",
                    Type = (int)BrandTypeEnum.Luxury,
                    Description = "Description"
                },
                new Brand
                {
                    Id = 6,
                    Name = "Test Brand 6",
                    Type = (int)BrandTypeEnum.Luxury,
                    Description = "Description"
                }
            );
            #endregion

            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of Rookie Shop" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of Rookie Shop" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of Rookie Shop" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi", SeoAlias = "ao-nam", SeoDescription = "áo thời trang nam", SeoTitle = "áo thời trang nam" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en", SeoAlias = "men-shirt", SeoDescription = "The shirt for men", SeoTitle = "The shirt for men" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi", SeoAlias = "ao-nu", SeoDescription = "áo thời trang nữ", SeoTitle = "áo thời trang nữ" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en", SeoAlias = "women-shirt", SeoDescription = "The shirt for women", SeoTitle = "The shirt for women" }
                  );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0,
                });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo sơ mi nam",
                     LanguageId = "vi",
                     SeoAlias = "ao-so-mi-nam",
                     SeoDescription = "Áo sơ mi nam",
                     SeoTitle = "Áo sơ mi nam",
                     Details = "Áo sơ mi nam",
                     Description = "Áo sơ mi nam"
                 },
                 new ProductTranslation()
                 {
                     Id = 2,
                     ProductId = 1,
                     Name = "Men T-Shirt",
                     LanguageId = "en",
                     SeoAlias = "men-t-shirt",
                     SeoDescription = "Men T-Shirt",
                     SeoTitle = "Men T-Shirt",
                     Details = "Men T-Shirt",
                     Description = "Men T-Shirt"
                 });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            var roleAdminId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var roleUserId = new Guid("35c242f0-1238-4fd0-9450-00a6d3cf9573");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            var userId = new Guid("d1e5705a-03e0-4d86-8396-b639cedef1b7");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleAdminId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                },
                new AppRole
                {
                    Id = roleUserId,
                    Name = "user",
                    NormalizedName = "user",
                    Description = "User role"
                }
                );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser("admin")
                {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Tyty@123"),
                    SecurityStamp = string.Empty,
                    FirstName = "Admin",
                    LastName = "Ad",
                    Dob = new DateTime(2020, 01, 31)
                },
                new AppUser("user")
                {
                    Id = userId,
                    UserName = "user",
                    NormalizedUserName = "user",
                    Email = "user@gmail.com",
                    NormalizedEmail = "user@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Tyty@123"),
                    SecurityStamp = string.Empty,
                    FirstName = "User",
                    LastName = "Us",
                    Dob = new DateTime(2020, 01, 31)
                }
                );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleAdminId,
                    UserId = adminId
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = roleUserId,
                    UserId = userId
                }
                );

            modelBuilder.Entity<Slide>().HasData(
                new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 1, Url = "#", Image = "/slides/slide-01.jpg", Status = Status.Active },
                new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 2, Url = "#", Image = "/slides/slide-02.jpg", Status = Status.Active },
                new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 3, Url = "#", Image = "/slides/slide-03.jpg", Status = Status.Active },
                new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 4, Url = "#", Image = "/slides/slide-04.jpg", Status = Status.Active },
                new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 5, Url = "#", Image = "/slides/slide-05.jpg", Status = Status.Active },
                new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio", SortOrder = 6, Url = "#", Image = "/slides/slide-06.jpg", Status = Status.Active }
                );
        }
    }
}
