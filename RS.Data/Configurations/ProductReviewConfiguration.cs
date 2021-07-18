using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using RS.Data.Entities;

namespace RS.Data.Configurations
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable("ProductReviews");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Comment).HasMaxLength(500);
            builder.Property(x => x.PublishedDate);
            builder.HasOne(x => x.Products).WithMany(x => x.ProductReviews).HasForeignKey(x => x.ProductId);
        }
    }
}
