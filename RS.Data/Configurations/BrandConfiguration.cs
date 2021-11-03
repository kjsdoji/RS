using System;
using System.Collections.Generic;
using System.Text;
using RS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.Data.Enums;

namespace RS.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Type).IsRequired().HasDefaultValue(BrandTypeEnum.Normal);
            builder.Property(x => x.ImageName);
            builder.Property(x => x.IsDeleted);
        }
    }
}
